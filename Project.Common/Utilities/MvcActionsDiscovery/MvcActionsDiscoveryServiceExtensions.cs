using Microsoft.Extensions.DependencyInjection;

namespace Project.Common.Utilities.MvcActionsDiscovery
{
    public static class MvcActionsDiscoveryServiceExtensions
    {
        public static IServiceCollection AddMvcActionsDiscoveryService(this IServiceCollection services)
        {
            services.AddSingleton<IMvcActionsDiscoveryService, MvcActionsDiscoveryService>();
            return services;
        }
    }
}
