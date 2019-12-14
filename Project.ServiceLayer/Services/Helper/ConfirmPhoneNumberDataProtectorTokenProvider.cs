using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Project.ServiceLayer.Services.Helper
{
    public class ConfirmPhoneNumberDataProtectorTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public ConfirmPhoneNumberDataProtectorTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<ConfirmPhoneNumberDataProtectionTokenProviderOptions> options)
            : base(dataProtectionProvider, options)
        {
            // NOTE: DataProtectionTokenProviderOptions.TokenLifespan is set to TimeSpan.FromDays(1)
            // which is low for the `ConfirmPhoneNumber` task.

        }
    }
}