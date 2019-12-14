using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Project.Common.Extensions;
using Project.DomainClasses.Enums.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class UserTokenValidatorService : IUserTokenValidatorService
    {
        private readonly IUserService _userService;
        private readonly IUserTokenStorageService _userTokenStorageService;

        public UserTokenValidatorService(IUserService userService, IUserTokenStorageService userTokenStorageService)
        {
            _userService = userService;
            _userService.CheckArgumentIsNull(nameof(userService));

            _userTokenStorageService = userTokenStorageService;
            _userTokenStorageService.CheckArgumentIsNull(nameof(_userTokenStorageService));
        }

        public async Task ValidateAsync(TokenValidatedContext context)
        {
            var userPrincipal = context.Principal;

            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }

            var serialNumberClaim = claimsIdentity.FindFirst(ClaimTypes.SerialNumber);
            if (serialNumberClaim == null)
            {
                context.Fail("This is not our issued token. It has no serial.");
                return;
            }

            var userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
            if (!Guid.TryParse(userIdString, out var userId))
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return;
            }

            var user = await _userService.FindByIdAsync(userId);
            //if (user == null || user.SerialNumber != serialNumberClaim.Value)
            //{
            //    // user has changed his/her password/roles/stat/IsActive
            //    context.Fail("This token is expired. Please login again.");
            //    return;
            //}

            //if (user.UserStatus != UserStatus.Active)
            //{
            //    context.Fail("This user is not active.");
            //    return;
            //}

            var accessToken = context.SecurityToken as JwtSecurityToken;
            if (accessToken == null || string.IsNullOrWhiteSpace(accessToken.RawData) ||
                !await _userTokenStorageService.IsValidTokenAsync(accessToken.RawData, userId))
            {
                context.Fail("This token is not in our database.");
                return;
            }

            await _userService.UpdateLastActivityDateTimeAsync(userId);
        }
    }
}
