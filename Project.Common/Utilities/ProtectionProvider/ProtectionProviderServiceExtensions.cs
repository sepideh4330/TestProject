using Microsoft.Extensions.DependencyInjection;

namespace Project.Common.Utilities.ProtectionProvider
{
    public static class ProtectionProviderServiceExtensions
    {
        public static IServiceCollection AddProtectionProviderService(this IServiceCollection services)
        {
            services.AddSingleton<IProtectionProviderService, ProtectionProviderService>();
            return services;
        }
    }
}
