using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Common.Extensions
{
    public static class LocalizationExtensions
    {
        public static void AddResourceLocalizations(this IServiceCollection services)
        {
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Files";
            });
        }

        public static IMvcBuilder AddResourceViewLocalizations(this IMvcBuilder builder)
        {
            builder.AddResourceViewLocalizations()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(
                        baseName: type.FullName,
                        location: "Project.Resources");
                });
            ;
            return builder;
        }
        public static void UseRequestLocalizations(this IApplicationBuilder app)
        {
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("fa-IR")),
                SupportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fa-IR")
                },
                SupportedUICultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fa-IR")
                }
            });
        }
    }
}
