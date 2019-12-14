using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;
using Project.ServiceLayer.Services.Helper;

namespace Project.ServiceLayer.Services.Identities
{
    public class UserTokenFactoryService : IUserTokenFactoryService
    {
        private readonly ISecurityService _securityService;
        private readonly IGroupRoleService _groupRoleService;
        private readonly BearerTokensOptions _bearerTokensOptions;
        private readonly ILogger<UserTokenFactoryService> _logger;

        public UserTokenFactoryService(
            ISecurityService securityService,
            IGroupRoleService groupRoleService,
            IOptionsSnapshot<SiteSettings> options,
            ILogger<UserTokenFactoryService> logger)
        {
            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _groupRoleService = groupRoleService;
            _groupRoleService.CheckArgumentIsNull(nameof(groupRoleService));

            _bearerTokensOptions = options.Value.BearerTokensOptions;

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(logger));
        }


        public async Task<JwtTokensData> CreateJwtTokensAsync(User user)
        {
            var (accessToken, claims) = await CreateAccessTokenAsync(user);
            var (refreshTokenValue, refreshTokenSerial) = CreateRefreshToken();
            return new JwtTokensData
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue,
                RefreshTokenSerial = refreshTokenSerial,
                Claims = claims
            };
        }

        private (string RefreshTokenValue, string RefreshTokenSerial) CreateRefreshToken()
        {
            var refreshTokenSerial = _securityService.CreateCryptographicallySecureGuid().GetCleanGuidValue();

            var claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, _securityService.CreateCryptographicallySecureGuid().ToString(), ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                // Issuer
                new Claim(JwtRegisteredClaimNames.Iss, _bearerTokensOptions.Issuer, ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _bearerTokensOptions.Issuer),
                // for invalidation
                new Claim(ClaimTypes.SerialNumber, refreshTokenSerial, ClaimValueTypes.String, _bearerTokensOptions.Issuer)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_bearerTokensOptions.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _bearerTokensOptions.Issuer,
                audience: _bearerTokensOptions.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_bearerTokensOptions.RefreshTokenExpirationMinutes),
                signingCredentials: creds);
            var refreshTokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return (refreshTokenValue, refreshTokenSerial);
        }

        public string GetRefreshTokenSerial(string refreshTokenValue)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                return null;
            }

            ClaimsPrincipal decodedRefreshTokenPrincipal = null;
            try
            {
                decodedRefreshTokenPrincipal = new JwtSecurityTokenHandler().ValidateToken(
                    refreshTokenValue,
                    new TokenValidationParameters
                    {
                        RequireExpirationTime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_bearerTokensOptions.Key)),
                        ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                        ValidateLifetime = true, // validate the expiration
                        ClockSkew = TimeSpan.Zero // tolerance for the expiration date
                    },
                    out _
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to validate refreshTokenValue: `{refreshTokenValue}`.");
            }

            return decodedRefreshTokenPrincipal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber)?.Value;
        }

        private async Task<(string AccessToken, IEnumerable<Claim> Claims)> CreateAccessTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, _securityService.CreateCryptographicallySecureGuid().ToString(), ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                // Issuer
                new Claim(JwtRegisteredClaimNames.Iss, _bearerTokensOptions.Issuer, ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _bearerTokensOptions.Issuer),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ExtraClaimTypes.FullName, user.FullName),
                new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                // to invalidate the cookie
                new Claim(ClaimTypes.SerialNumber, "serialnumber", ClaimValueTypes.String, _bearerTokensOptions.Issuer),
                // custom data
                new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, _bearerTokensOptions.Issuer)
            };

            // add roles
            if (user.GroupId != null)
            {
                var roleNames = await _groupRoleService.FindUserRoleEnNamesAsync(user.GroupId.Value);
                foreach (var role in roleNames)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, _bearerTokensOptions.Issuer));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_bearerTokensOptions.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _bearerTokensOptions.Issuer,
                audience: _bearerTokensOptions.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(1000000),
                signingCredentials: creds);
            return (new JwtSecurityTokenHandler().WriteToken(token), claims);
        }
    }
}
