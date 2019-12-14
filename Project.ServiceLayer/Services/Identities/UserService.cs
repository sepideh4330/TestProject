using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.Common.Helpers;
using Project.Common.Utilities.DtoHelper;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.DomainClasses.Enums.Identities;
using Project.DomainClasses.Extensions.Identities;
using Project.Dto.User.ChangeMyUserPassword;
using Project.Dto.User.ForgotPassword;
using Project.Dto.User.GetMyProfile;
using Project.Dto.User.Login;
using Project.Dto.User.RefreshToken;
using Project.Dto.User.Register;
using Project.Dto.User.ResetPassword;
using Project.Dto.User.VerificationPhoneNumber;
using Project.ServiceLayer.Contracts.Identities;
using Project.ServiceLayer.Contracts.Messages;
using Project.ServiceLayer.Messages;

namespace Project.ServiceLayer.Services.Identities
{
    public class UserService : UserManager<User>, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IAntiForgeryCookieService _antiForgeryCookieService;
        private readonly IOptionsSnapshot<SiteSettings> _options;
        private readonly IUsedPasswordService _usedPasswordService;
        private readonly IUserTokenFactoryService _userTokenFactoryService;
        private readonly IdentityErrorDescriber _identityErrorDescriber;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly ISecurityService _securityService;
        private readonly ILogger<UserService> _logger;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        private readonly IServiceProvider _serviceProvider;
        private readonly DbSet<User> _users;
        private readonly DbSet<Role> _roles;
        private readonly IUserStoreService _userStoreService;
        private readonly IUserTokenStorageService _userTokenStorageService;
        private readonly IEnumerable<IUserValidator<User>> _userValidators;
        private readonly SmsTemplates _smsTemplates;
        private readonly StringEncryption _stringEncryption;
        private readonly IMapper _mapper;


        public UserService(
            IUserStoreService userStoreService,
            IUserTokenStorageService userTokenStorageService,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            ISecurityService securityService,
            IdentityErrorDescriber identityErrorDescriber,
            IServiceProvider serviceProvider,
            ILogger<UserService> logger,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            IAntiForgeryCookieService antiForgeryCookieService,
            IOptionsSnapshot<SiteSettings> options,
            IUsedPasswordService usedPasswordService,
            IUserTokenFactoryService userTokenFactoryService,
            IMapper mapper)
            : base((IUserStore<User>)userStoreService, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, identityErrorDescriber, serviceProvider, logger)
        {
            _userStoreService = userStoreService;
            _userStoreService.CheckArgumentIsNull(nameof(_userStoreService));

            _userTokenStorageService = userTokenStorageService;
            _userTokenStorageService.CheckArgumentIsNull(nameof(_userTokenStorageService));

            _optionsAccessor = optionsAccessor;
            _optionsAccessor.CheckArgumentIsNull(nameof(_optionsAccessor));

            _passwordHasher = passwordHasher;
            _passwordHasher.CheckArgumentIsNull(nameof(_passwordHasher));

            _userValidators = userValidators;
            _userValidators.CheckArgumentIsNull(nameof(_userValidators));

            _passwordValidators = passwordValidators;
            _passwordValidators.CheckArgumentIsNull(nameof(_passwordValidators));

            _keyNormalizer = keyNormalizer;
            _keyNormalizer.CheckArgumentIsNull(nameof(_keyNormalizer));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _identityErrorDescriber = identityErrorDescriber;
            _identityErrorDescriber.CheckArgumentIsNull(nameof(_identityErrorDescriber));

            _serviceProvider = serviceProvider;
            _serviceProvider.CheckArgumentIsNull(nameof(_serviceProvider));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));

            _stringEncryption = new StringEncryption();
            _stringEncryption.CheckArgumentIsNull(nameof(_stringEncryption));

            _httpContextAccessor = httpContextAccessor;
            _httpContextAccessor.CheckArgumentIsNull(nameof(_httpContextAccessor));

            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _usedPasswordService = usedPasswordService;
            _userTokenFactoryService = userTokenFactoryService;
            _mapper = mapper;
            _usedPasswordService.CheckArgumentIsNull(nameof(_usedPasswordService));

            _antiForgeryCookieService = antiForgeryCookieService;
            _antiForgeryCookieService.CheckArgumentIsNull(nameof(_antiForgeryCookieService));

            _emailService = emailService;
            _emailService.CheckArgumentIsNull(nameof(_emailService));

            options.CheckArgumentIsNull(nameof(options));
            _options = options;
            _smsTemplates = options.Value.SmsTemplates;

            _users = _unitOfWork.Set<User>();
            _roles = _unitOfWork.Set<Role>();
        }

        public Guid GetCurrentUserId()
        {
            var test = _httpContextAccessor.HttpContext.User;
            return _httpContextAccessor.HttpContext.User.Identity.GetUserId().ToGuid();
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await base.FindByIdAsync(userId.ToString()).ConfigureAwait(false);
        }

        public async Task UpdateLastActivityDateTimeAsync(Guid userId)
        {
            var user = await FindByIdAsync(userId).ConfigureAwait(false);
            if (user != null)
            {
                user.LastActivityDateTimeOn = DateTimeOffset.UtcNow.IranStandardTimeNow();
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdateLastLoginDateTimeAsync(Guid userId)
        {
            var user = await FindByIdAsync(userId).ConfigureAwait(false);
            if (user != null)
            {
                user.LastLoginDateTimeOn = DateTimeOffset.UtcNow.IranStandardTimeNow();
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdateLastVisitDateTimeAsync(ClaimsPrincipal claimsPrincipal)
        {
            var user = await GetUserAsync(claimsPrincipal).ConfigureAwait(false);
            if (user != null)
            {
                user.LastVisitDateTimeOn = DateTimeOffset.UtcNow.IranStandardTimeNow();
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = new LoginResponse();
            var passwordHash = _securityService.GetSha256Hash(request.Password);
            var user = await _users
                .Include(d => d.Group)
                .ThenInclude(d => d.GroupRoles)
                .ThenInclude(d => d.Role)
                .FirstOrDefaultAsync(x => x.UserName == request.UserName && x.PasswordHash == passwordHash);
            if (user == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.InvalidUserNameOrPasswordForLogin.Value(), AuthenticationMessageHelper.ResponseMessages);
            }

            switch (user.UserStatus)
            {
                case UserStatus.Fired:
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.LoginFailedYouAreFired.Value(), AuthenticationMessageHelper.ResponseMessages);
                case UserStatus.Inactive:
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.LoginFailedYouAreInactive.Value(), AuthenticationMessageHelper.ResponseMessages);
                case UserStatus.WaitingConfirmationEmail:
                    var token = await SendAndGetVerificationEmailTokenAsync(user);
                    await SetEmailTokenAsync(user.Id, token);
                    await _unitOfWork.SaveChangesAsync();
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.LoginFailedYouAreWaitingVerificationEmail.Value(), AuthenticationMessageHelper.ResponseMessages);
            }

            user.LastLoginDateTimeOn = DateTimeOffset.UtcNow.IranStandardTimeNow();
            user.CleanEmailToken();
            var result = await _userTokenFactoryService.CreateJwtTokensAsync(user);
            await _userTokenStorageService.AddUserTokenStorageAsync(user, result.RefreshTokenSerial, result.AccessToken, null);
            await _unitOfWork.SaveChangesAsync();
            _antiForgeryCookieService.RegenerateAntiForgeryCookies(result.Claims);
            response.access_token = result.AccessToken;
            response.refresh_token = result.RefreshToken;
            response.UserId = user.Id;
            response.FullName = user.FullName;
            response.UserName = user.UserName;
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.LoginSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var response = new RefreshTokenResponse();
            if (request.refreshToken.IsGuid())
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.InvalidRefresh.Value(), AuthenticationMessageHelper.ResponseMessages);
            }

            var token = await _userTokenStorageService.FindTokenAsync(request.refreshToken);
            if (token == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.TokenUnauthorizedForRefreshToken.Value(), AuthenticationMessageHelper.ResponseMessages);
            }

            var result = await _userTokenFactoryService.CreateJwtTokensAsync(token.User);
            await _userTokenStorageService.AddUserTokenStorageAsync(token.User, result.RefreshTokenSerial, result.AccessToken, _userTokenFactoryService.GetRefreshTokenSerial(request.refreshToken));
            await _unitOfWork.SaveChangesAsync();
            _antiForgeryCookieService.RegenerateAntiForgeryCookies(result.Claims);
            response.refresh_token = result.RefreshToken;
            response.access_token = result.AccessToken;
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.RefreshTokenSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;
            await _userTokenStorageService.RevokeUserBearerTokensAsync(userIdValue, refreshToken);
            await _unitOfWork.SaveChangesAsync();
            _antiForgeryCookieService.DeleteAntiForgeryCookies();
            return true;
        }

        public async Task<VerificationEmailResponse> VerificationEmailAsync(VerificationEmailRequest request)
        {
            var response = new VerificationEmailResponse();
            var user = await _users.FirstOrDefaultAsync(d => d.UserName == request.UserName);
            if (user == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.VerificationEmailFailedInvalidUser.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            if (user.UserStatus != UserStatus.WaitingConfirmationEmail)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.VerificationEmailFailedInvalidUserStatus.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            if (!user.EmailTokenLifespanDateTimeOn.HasValue || string.IsNullOrEmpty(user.EmailToken))
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.VerificationEmailFailedInvalidTokenData.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            var decryptEmailToken = _stringEncryption.Decrypt(user.EmailToken);
            if (decryptEmailToken != request.VerificationEmailToken)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.VerificationEmailFailedInvalidTokenCode.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            if (user.EmailTokenLifespanDateTimeOn.Value <= DateTimeOffset.UtcNow.IranStandardTimeNow())
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.VerificationEmailFailedExpiredTokenCode.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            user.UserStatus = UserStatus.Active;
            user.EmailConfirmed = true;
            user.CleanEmailToken();
            await _unitOfWork.SaveChangesAsync();
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.VerificationEmailSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var response = new ForgotPasswordResponse();
            var user = await _users.FirstOrDefaultAsync(d => d.UserName == request.UserName);
            if (user == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ForgotPasswordFailedInvalidUser.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            switch (user.UserStatus)
            {
                case UserStatus.Fired:
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.ForgotPasswordFailedYouAreFired.Value(), AuthenticationMessageHelper.ResponseMessages);
                case UserStatus.Inactive:
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.ForgotPasswordFailedYouAreInactive.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            var token = await SendAndGetForgotPasswordTokenAsync(user);
            await SetEmailTokenAsync(user.Id, token);
            await _unitOfWork.SaveChangesAsync();
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.ForgotPasswordSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var response = new ResetPasswordResponse();
            var user = await _users.FirstOrDefaultAsync(d => d.UserName == request.UserName);
            if (user == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordFailedInvalidUser.Value(), AuthenticationMessageHelper.ResponseMessages);
            }

            var passwordBanedList = _options.Value.PasswordsBanList;
            if (passwordBanedList.Any(d => d == request.NewPassword))
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordSimplePass.Value(),
                    AuthenticationMessageHelper.ResponseMessages);
            }

            switch (user.UserStatus)
            {
                case UserStatus.Fired:
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordFailedYouAreFired.Value(), AuthenticationMessageHelper.ResponseMessages);
                case UserStatus.Inactive:
                    return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordFailedYouAreInactive.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            if (!user.EmailTokenLifespanDateTimeOn.HasValue || string.IsNullOrEmpty(user.EmailToken))
            {
                user.CleanEmailToken();
                await _unitOfWork.SaveChangesAsync();
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordFailedInvalidTokenData.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            var decryptEmailToken = _stringEncryption.Decrypt(user.EmailToken);
            if (decryptEmailToken != request.ResetPasswordToken)
            {
                user.CleanEmailToken();
                await _unitOfWork.SaveChangesAsync();
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordFailedInvalidTokenCode.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            if (user.EmailTokenLifespanDateTimeOn.Value <= DateTimeOffset.UtcNow.IranStandardTimeNow())
            {
                user.CleanEmailToken();
                await _unitOfWork.SaveChangesAsync();
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordFailedExpiredTokenCode.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            user.PasswordHash = _securityService.GetSha256Hash(request.NewPassword);
            user.CleanEmailToken();
            await _unitOfWork.SaveChangesAsync();
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.ResetPasswordSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<ChangeMyUserPasswordResponse> ChangeMyUserPasswordAsync(ChangeMyUserPasswordRequest request)
        {
            var response = new ChangeMyUserPasswordResponse();
            var user = await _users.FirstOrDefaultAsync(d => d.Id == request.Id);
            if (user == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ChangeMyUserPasswordDoesNotExist.Value(),
                    AuthenticationMessageHelper.ResponseMessages);
            }

            var passwordBanedList = _options.Value.PasswordsBanList;
            if (passwordBanedList.Any(d => d == request.NewPassword))
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ChangeMyUserPasswordSimplePass.Value(),
                    AuthenticationMessageHelper.ResponseMessages);
            }

            if (user.PasswordHash != _securityService.GetSha256Hash(request.OldPassword))
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.ChangeMyUserPasswordInvalidOldPassword.Value(),
                    AuthenticationMessageHelper.ResponseMessages);
            }

            user.PasswordHash = _securityService.GetSha256Hash(request.NewPassword);

            await _unitOfWork.SaveChangesAsync();

            return response.ReturnWithCode(AuthenticationMessageHelper.Code.ChangeMyUserPasswordSuccess.Value(),
                AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<GetMyProfileResponse> GetMyProfileAsync()
        {
            var response = new GetMyProfileResponse();
            var user = await _users.AsNoTracking()
                .Include(d => d.Group)
                .FirstOrDefaultAsync(d => d.Id == GetCurrentUserId());
            if (user == null)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.GetMyProfileDoesNotExist.Value(),
                    AuthenticationMessageHelper.ResponseMessages);
            }

            _mapper.Map(user, response);

            return response.ReturnWithCode(AuthenticationMessageHelper.Code.GetMyProfileSuccess.Value(),
                AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var response = new RegisterResponse();
            var userFinded = await _users.AsNoTracking()
                .AnyAsync(d => d.Email.ToLower() == request.Email.ToLower().Trim());
            if (userFinded)
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.UserExists.Value(), AuthenticationMessageHelper.ResponseMessages);
            }
            var passwordBanedList = _options.Value.PasswordsBanList;
            if (passwordBanedList.Any(d => d == request.Password))
            {
                return response.ReturnWithCode(AuthenticationMessageHelper.Code.RegisterUserInvalidPass.Value(),
                    AuthenticationMessageHelper.ResponseMessages);
            }
            var user = _mapper.Map<User>(request);
            user.PasswordHash = _securityService.GetSha256Hash(request.Password);
            user.NormalizedEmail = _keyNormalizer.Normalize(user.Email);
            user.NormalizedUserName = _keyNormalizer.Normalize(user.UserName);
            _users.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.RegisterSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        #region Private members
        private async Task<string> SendAndGetForgotPasswordTokenAsync(User user)
        {
            var code = RandomNumber.GetRandomNumberLength(_options.Value.ForgotPasswordTokenLength).ToString();
            await _emailService.SendEmailAsync(user.Email, "کد تایید", string.Format(_smsTemplates.SendForgotPassword, code));
            return code;
        }

        private async Task<string> SendAndGetVerificationEmailTokenAsync(User user)
        {
            var code = RandomNumber.GetRandomNumberLength(_options.Value.VerificationEmailTokenLength).ToString();
            await _emailService.SendEmailAsync(user.Email, "کد تایید", string.Format(_smsTemplates.SendForgotPassword, code));
            return code;
        }

        private async Task SetEmailTokenAsync(Guid userId, string token)
        {
            var user = await _users.FirstAsync(d => d.Id == userId);
            user.EmailToken = _stringEncryption.Encrypt(token);
            user.EmailTokenLifespanDateTimeOn = DateTimeOffset.UtcNow.IranStandardTimeNow().Add(_options.Value.ConfirmationTokenProviderLifespan);
        }

        #endregion
    }
}
