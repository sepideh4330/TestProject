using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Project.Common.Extensions;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Helper
{
    public class CustomSecurityStampValidator : SecurityStampValidator<User>
    {
        private readonly IOptions<SecurityStampValidatorOptions> _options;
        private readonly ISignInService _signInService;
        private readonly IUserService _userService;
        private readonly ISiteStateService _siteStateService;
        private readonly ISystemClock _systemClock;

        public CustomSecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            ISignInService signInService,
            IUserService userService,
            ISystemClock systemClock,
            ISiteStateService siteStateService)
            : base(options, (SignInManager<User>)signInService, systemClock)
        {
            _options = options;
            _options.CheckArgumentIsNull(nameof(_options));

            _signInService = signInService;
            _userService = userService;
            _signInService.CheckArgumentIsNull(nameof(_signInService));

            _siteStateService = siteStateService;
            _siteStateService.CheckArgumentIsNull(nameof(_siteStateService));

            _systemClock = systemClock;
        }

        public TimeSpan UpdateLastModifiedDate { get; set; } = TimeSpan.FromMinutes(2);

        public override async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            await base.ValidateAsync(context).ConfigureAwait(false);
            await updateUserLastVisitDateTimeAsync(context).ConfigureAwait(false);
        }

        private async Task updateUserLastVisitDateTimeAsync(CookieValidatePrincipalContext context)
        {
            var currentUtc = DateTimeOffset.UtcNow.IranStandardTimeNow();
            if (context.Options != null && _systemClock != null)
            {
                currentUtc = _systemClock.UtcNow.IranStandardTimeNow();
            }
            var issuedUtc = context.Properties.IssuedUtc;

            // Only validate if enough time has elapsed
            if (issuedUtc == null || context.Principal == null)
            {
                return;
            }

            var timeElapsed = currentUtc.Subtract(issuedUtc.Value);
            if (timeElapsed > UpdateLastModifiedDate)
            {
                await _userService.UpdateLastVisitDateTimeAsync(context.Principal).ConfigureAwait(false);
            }
        }
    }
}
