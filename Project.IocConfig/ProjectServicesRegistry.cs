using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.IocConfig
{
    public static class ProjectServicesRegistry
    {
        public static void AddBusinessServicesRegistry(this IServiceCollection services)
        {
            var siteSettings = GetSiteSettings(services);
            services.AddBusinessServices();
            services.AddBusinessOptions(siteSettings);
        }

        public static SiteSettings GetSiteSettings(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var siteSettingsOptions = provider.GetService<IOptionsSnapshot<SiteSettings>>();
            siteSettingsOptions.CheckArgumentIsNull(nameof(siteSettingsOptions));
            var siteSettings = siteSettingsOptions.Value;
            siteSettings.CheckArgumentIsNull(nameof(siteSettings));
            return siteSettings;
        }

        public static void UseBusinessServices(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            //app.CallDataInitializer();
            //app.CallBusinessDataInitializer();
        }

        private static void CallDataInitializer(this IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitialize = scope.ServiceProvider.GetService<IIdentityDataInitializerService>();
                dbInitialize.SeedRoles();
                dbInitialize.AddReferenceRoles();
                dbInitialize.SeedGroups();
                dbInitialize.SeedUsers();
            }
        }

    }
}
