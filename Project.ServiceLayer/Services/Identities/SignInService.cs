using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Common.Extensions;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class SignInService : SignInManager<User>, ISignInService
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserClaimsPrincipalFactory<User> _userClaimsPrincipalFactory;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly ILogger<SignInService> _logger;
        private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;

        public SignInService(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor,
            IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInService> logger,
            IAuthenticationSchemeProvider authenticationSchemeProvider)
            : base((UserManager<User>)userService, httpContextAccessor, userClaimsPrincipalFactory, optionsAccessor, logger, authenticationSchemeProvider)
        {
            _userService = userService;
            _userService.CheckArgumentIsNull(nameof(_userService));

            _httpContextAccessor = httpContextAccessor;
            _httpContextAccessor.CheckArgumentIsNull(nameof(_httpContextAccessor));

            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userClaimsPrincipalFactory.CheckArgumentIsNull(nameof(_userClaimsPrincipalFactory));

            _optionsAccessor = optionsAccessor;
            _optionsAccessor.CheckArgumentIsNull(nameof(_optionsAccessor));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));

            _authenticationSchemeProvider = authenticationSchemeProvider;
            _authenticationSchemeProvider.CheckArgumentIsNull(nameof(_authenticationSchemeProvider));
        }
    }
}
