using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Project.Common.AppSettings;

namespace Project.DataLayer.Context
{
    public static class DbContextOptionsExtensions
    {
        public static void AddRequiredEfInternalServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkSqlServer();
        }

        public static void SetDbContextOptions(
            this DbContextOptionsBuilder optionsBuilder,
            SiteSettings siteSettings)
        {
            optionsBuilder.UseSqlServer(
                siteSettings.ConnectionStrings.SqlServer.ApplicationDbContextConnection
                , serverDbContextOptionsBuilder =>
                {
                    var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                    serverDbContextOptionsBuilder.CommandTimeout(minutes);
                    serverDbContextOptionsBuilder.EnableRetryOnFailure();
                });
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Log(CoreEventId.IncludeIgnoredWarning);
                warnings.Log(RelationalEventId.QueryClientEvaluationWarning);
            });
        }
    }
}
