using Microsoft.AspNetCore.Builder;
using Project.Common.Utilities.Middlewares;

namespace Project.Common.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}
