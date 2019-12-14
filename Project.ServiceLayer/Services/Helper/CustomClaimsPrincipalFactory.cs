using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Project.Common.Extensions;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Helper
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public static readonly string PhotoFileName = nameof(PhotoFileName);

        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public CustomClaimsPrincipalFactory(
            IUserService userService,
            IRoleService roleService,
            IOptions<IdentityOptions> optionsAccessor)
            : base((UserManager<User>)userService, (RoleManager<Role>)roleService, optionsAccessor)
        {
            _userService = userService;
            _userService.CheckArgumentIsNull(nameof(_userService));

            _roleService = roleService;
            _roleService.CheckArgumentIsNull(nameof(_roleService));

            _optionsAccessor = optionsAccessor;
            _optionsAccessor.CheckArgumentIsNull(nameof(_optionsAccessor));
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user).ConfigureAwait(false); // adds all `Options.ClaimsIdentity.RoleClaimType -> Role Claims` automatically + `Options.ClaimsIdentity.UserIdClaimType -> userId` & `Options.ClaimsIdentity.UserNameClaimType -> userName`
            AddCustomClaims(user, principal);
            return principal;
        }

        private static void AddCustomClaims(User user, IPrincipal principal)
        {
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.GivenName, user.FirstName ?? string.Empty),
                new Claim(ClaimTypes.Surname, user.LastName ?? string.Empty),
            });
        }
    }
}
