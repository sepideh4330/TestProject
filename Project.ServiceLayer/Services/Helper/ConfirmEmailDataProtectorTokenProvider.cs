using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Project.ServiceLayer.Services.Helper
{
    public class ConfirmEmailDataProtectorTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public ConfirmEmailDataProtectorTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<ConfirmEmailDataProtectionTokenProviderOptions> options)
            : base(dataProtectionProvider, options)
        {
            // NOTE: DataProtectionTokenProviderOptions.TokenLifespan is set to TimeSpan.FromDays(1)
            // which is low for the `ConfirmEmail` task.
        }
    }
}
