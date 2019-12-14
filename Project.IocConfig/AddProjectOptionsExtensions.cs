using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Services.Helper;
using Project.ServiceLayer.Services.Identities;

namespace Project.IocConfig
{
    public static class AddProjectOptionsExtensions
    {
        public const string EmailConfirmationTokenProviderName = "ConfirmEmail";
        public const string PhoneNumberConfirmationTokenProviderName = "Phone";

        public static IServiceCollection AddBusinessOptions(
            this IServiceCollection services, SiteSettings siteSettings)
        {
            siteSettings.CheckArgumentIsNull(nameof(siteSettings));

            services.AddConfirmEmailDataProtectorTokenOptions(siteSettings);
            services.AddIdentity<User, Role>(identityOptions =>
            {
                SetPasswordOptions(identityOptions.Password, siteSettings);
                SetSignInOptions(identityOptions.SignIn, siteSettings);
                SetUserOptions(identityOptions.User);
                SetLockoutOptions(identityOptions.Lockout, siteSettings);
            }).AddUserStore<UserStoreService>()
              .AddUserManager<UserService>()
              .AddRoleStore<RoleStoreService>()
              .AddRoleManager<RoleService>()
              .AddSignInManager<SignInService>()
              .AddErrorDescriber<CustomIdentityErrorDescriber>()
              // You **cannot** use .AddEntityFrameworkStores() when you customize everything
              //.AddEntityFrameworkStores<ApplicationDbContext, int>()
              .AddDefaultTokenProviders()
              .AddTokenProvider<ConfirmEmailDataProtectorTokenProvider<User>>(EmailConfirmationTokenProviderName)
              .AddTokenProvider<ConfirmPhoneNumberDataProtectorTokenProvider<User>>(PhoneNumberConfirmationTokenProviderName);

            services.ConfigureApplicationCookie(identityOptionsCookies =>
            {

            });

            services.EnableIimmediateLogout();

            return services;
        }

        private static void AddConfirmEmailDataProtectorTokenOptions(this IServiceCollection services, SiteSettings siteSettings)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Tokens.EmailConfirmationTokenProvider = EmailConfirmationTokenProviderName;
                options.Tokens.ChangePhoneNumberTokenProvider = PhoneNumberConfirmationTokenProviderName;
            });

            services.Configure<ConfirmEmailDataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = siteSettings.ConfirmationTokenProviderLifespan;
            });

            services.Configure<ConfirmPhoneNumberDataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = siteSettings.ConfirmationTokenProviderLifespan;
            });
        }

        private static void EnableIimmediateLogout(this IServiceCollection services)
        {
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
                options.OnRefreshingPrincipal = principalContext => Task.CompletedTask;
            });
        }
        private static void SetLockoutOptions(LockoutOptions identityOptionsLockout, SiteSettings siteSettings)
        {
            identityOptionsLockout.AllowedForNewUsers = siteSettings.LockoutOptions.AllowedForNewUsers;
            identityOptionsLockout.DefaultLockoutTimeSpan = siteSettings.LockoutOptions.DefaultLockoutTimeSpan;
            identityOptionsLockout.MaxFailedAccessAttempts = siteSettings.LockoutOptions.MaxFailedAccessAttempts;
        }

        private static void SetPasswordOptions(PasswordOptions identityOptionsPassword, SiteSettings siteSettings)
        {
            identityOptionsPassword.RequireDigit = siteSettings.PasswordOptions.RequireDigit;
            identityOptionsPassword.RequireLowercase = siteSettings.PasswordOptions.RequireLowercase;
            identityOptionsPassword.RequireNonAlphanumeric = siteSettings.PasswordOptions.RequireNonAlphanumeric;
            identityOptionsPassword.RequireUppercase = siteSettings.PasswordOptions.RequireUppercase;
            identityOptionsPassword.RequiredLength = siteSettings.PasswordOptions.RequiredLength;
        }

        private static void SetSignInOptions(SignInOptions identityOptionsSignIn, SiteSettings siteSettings)
        {
            identityOptionsSignIn.RequireConfirmedEmail = siteSettings.RequireConfirmedEmail;
            identityOptionsSignIn.RequireConfirmedPhoneNumber = siteSettings.RequireConfirmedPhoneNumber;
        }

        private static void SetUserOptions(UserOptions identityOptionsUser)
        {
            identityOptionsUser.RequireUniqueEmail = false;
        }
    }
}
