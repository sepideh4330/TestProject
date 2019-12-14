using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Project.Common.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static void ConfigWebRootPath(this IHostingEnvironment hostingEnvironment)
        {
            if (string.IsNullOrEmpty(hostingEnvironment.WebRootPath))
            {
                hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
        }
    }
}