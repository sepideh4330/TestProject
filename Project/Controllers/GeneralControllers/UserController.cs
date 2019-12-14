using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.Common.Controllers;
using Project.Common.Extensions;
using Project.Common.Helpers;
using Project.Common.StaticValues.Security;
using Project.Dto.User.ChangeMyUserPassword;
using Project.Dto.User.ForgotPassword;
using Project.Dto.User.GetMyProfile;
using Project.Dto.User.Login;
using Project.Dto.User.RefreshToken;
using Project.Dto.User.Register;
using Project.Dto.User.ResetPassword;
using Project.Dto.User.VerificationPhoneNumber;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.Controllers.GeneralControllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _userService.CheckArgumentIsNull(nameof(_userService));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("Login")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(LoginResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.LoginAsync(request));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("Register")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(RegisterResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.RegisterAsync(request));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("VerificationEmail")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(VerificationEmailResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        public async Task<IActionResult> VerificationEmail([FromBody] VerificationEmailRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.VerificationEmailAsync(request));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("ForgotPassword")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(ForgotPasswordResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.ForgotPasswordAsync(request));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("ResetPassword")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(ResetPasswordResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.ResetPasswordAsync(request));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("RefreshToken")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(RefreshTokenResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.RefreshTokenAsync(request));
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("ChangeMyUserPassword")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(ChangeMyUserPasswordResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        [Authorize(Roles = SystemRoles.ChangeMyPassword)]
        public async Task<IActionResult> ChangeMyUserPassword([FromBody]ChangeMyUserPasswordRequest request)
        {
            return await ExecuteServiceAsync(() => _userService.ChangeMyUserPasswordAsync(request));
        }

        [HttpGet("[action]")]
        [ActionName("GetMyProfile")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(GetMyProfileResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        [Authorize(Roles = SystemRoles.ShowMyProfile)]
        public async Task<IActionResult> GetMyProfile()
        {
            return await ExecuteServiceAsync(() => _userService.GetMyProfileAsync());
        }

        [HttpGet("[action]")]
        [ActionName("Logout")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            return await ExecuteServiceAsync(() => _userService.LogoutAsync(refreshToken));
        }

        [HttpPost("[action]")]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}