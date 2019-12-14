using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class UserTokenStorageService : IUserTokenStorageService
    {
        private readonly ISecurityService _securityService;
        private readonly IUserTokenFactoryService _userTokenFactoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<UserTokenStorage> _userTokenStorages;
        private readonly BearerTokensOptions _bearerTokensOptions;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        private readonly IGroupRoleService _groupRoleService;

        public UserTokenStorageService(
            IUnitOfWork unitOfWork,
            ISecurityService securityService,
            IUserTokenFactoryService userTokenFactoryService,
            IRoleService roleService,
            IUserRoleService userRoleService,
            IGroupRoleService groupRoleService,
            IOptionsSnapshot<SiteSettings> options)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _userTokenFactoryService = userTokenFactoryService;
            _userTokenFactoryService.CheckArgumentIsNull(nameof(userTokenFactoryService));

            _roleService = roleService;
            _roleService.CheckArgumentIsNull(nameof(roleService));

            _userRoleService = userRoleService;
            _userRoleService.CheckArgumentIsNull(nameof(_userRoleService));

            _groupRoleService = groupRoleService;
            _groupRoleService.CheckArgumentIsNull(nameof(_groupRoleService));

            options.CheckArgumentIsNull(nameof(options));
            _bearerTokensOptions = options.Value.BearerTokensOptions;

            _userTokenStorages = _unitOfWork.Set<UserTokenStorage>();
        }

        public async Task AddUserTokenStorageAsync(UserTokenStorage userTokenStorage)
        {
            if (!_bearerTokensOptions.AllowMultipleLoginsFromTheSameUser)
            {
                await InvalidateUserTokenStoragesAsync(userTokenStorage.UserId);
            }
            await DeleteTokensWithSameRefreshTokenSourceAsync(userTokenStorage.RefreshTokenIdHashSource);
            _userTokenStorages.Add(userTokenStorage);
        }

        public async Task AddUserTokenStorageAsync(User user, string refreshTokenSerial, string accessToken, string refreshTokenSourceSerial)
        {
            var now = DateTimeOffset.UtcNow;
            var token = new UserTokenStorage
            {
                UserId = user.Id,
                // Refresh token handles should be treated as secrets and should be stored hashed
                RefreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial),
                RefreshTokenIdHashSource = string.IsNullOrWhiteSpace(refreshTokenSourceSerial) ?
                    null : _securityService.GetSha256Hash(refreshTokenSourceSerial),
                AccessTokenHash = _securityService.GetSha256Hash(accessToken),
                RefreshTokenExpiresDateTimeOn = now.AddMinutes(_bearerTokensOptions.RefreshTokenExpirationMinutes),
                AccessTokenExpiresDateTimeOn = now.AddMinutes(_bearerTokensOptions.AccessTokenExpirationMinutes)
            };
            await AddUserTokenStorageAsync(token);
        }

        public async Task DeleteExpiredTokensAsync()
        {
            var now = DateTimeOffset.UtcNow;
            await _userTokenStorages.Where(x => x.RefreshTokenExpiresDateTimeOn < now)
                         .ForEachAsync(userTokenStorage =>
                         {
                             _userTokenStorages.Remove(userTokenStorage);
                         });
        }

        public async Task DeleteTokenAsync(string refreshToken)
        {
            var token = await FindTokenAsync(refreshToken);
            if (token != null)
            {
                _userTokenStorages.Remove(token);
            }
        }

        public async Task DeleteUserTokenAsync(Guid userId)
        {
            await _userTokenStorages.Where(x => x.UserId == userId)
                .ForEachAsync(userToken =>
                {
                    _userTokenStorages.Remove(userToken);
                });
        }

        public async Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource))
            {
                return;
            }
            await _userTokenStorages.Where(t => t.RefreshTokenIdHashSource == refreshTokenIdHashSource)
                         .ForEachAsync(userToken =>
                         {
                             _userTokenStorages.Remove(userToken);
                         });
        }

        public async Task RevokeUserBearerTokensAsync(string userIdValue, string refreshToken)
        {
            if (!string.IsNullOrWhiteSpace(userIdValue) && Guid.TryParse(userIdValue, out var userId))
            {
                if (_bearerTokensOptions.AllowSignoutAllUserActiveClients)
                {
                    await InvalidateUserTokenStoragesAsync(userId);
                }
            }

            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
                var refreshTokenIdHashSource = _securityService.GetSha256Hash(refreshToken);
                await DeleteTokensWithSameRefreshTokenSourceAsync(refreshTokenIdHashSource);
            }

            await DeleteExpiredTokensAsync();
        }

        public Task<UserTokenStorage> FindTokenAsync(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return null;
            }
            var refreshTokenSerial = _userTokenFactoryService.GetRefreshTokenSerial(refreshToken);
            if (string.IsNullOrWhiteSpace(refreshTokenSerial))
            {
                return null;
            }

            var refreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial);
            return _userTokenStorages.Include(x => x.User.Group)
                .ThenInclude(d => d.GroupRoles)
                .ThenInclude(d => d.Role).FirstOrDefaultAsync(x => x.RefreshTokenIdHash == refreshTokenIdHash);
        }

        public async Task InvalidateUserTokenStoragesAsync(Guid userId)
        {
            await _userTokenStorages.Where(x => x.UserId == userId)
                         .ForEachAsync(userToken =>
                         {
                             _userTokenStorages.Remove(userToken);
                         });
        }

        public async Task<bool> IsValidTokenAsync(string accessToken, Guid userId)
        {
            var accessTokenHash = _securityService.GetSha256Hash(accessToken);
            var userToken = await _userTokenStorages.FirstOrDefaultAsync(
                x => x.AccessTokenHash == accessTokenHash && x.UserId == userId);
            return userToken?.AccessTokenExpiresDateTimeOn >= DateTimeOffset.UtcNow;
        }
    }
}
