using Microsoft.EntityFrameworkCore;
using Project.Common.AppSettings;
using Project.DomainClasses.Configurations.Identities;

namespace Project.DomainClasses.Configurations.ModelBuilderExtensions
{
    public static class IdentityConfigs
    {
        public static void AddCustomIdentityConfigs(this ModelBuilder modelBuilder, SiteSettings siteSettings)
        {
            GroupConfig.Build(modelBuilder);
            GroupRoleConfig.Build(modelBuilder);
            GroupChangeLogConfig.Build(modelBuilder);
            RoleClaimConfig.Build(modelBuilder);
            RoleConfig.Build(modelBuilder);
            UserChangeLogConfig.Build(modelBuilder);
            UserClaimConfig.Build(modelBuilder);
            UserLoginConfig.Build(modelBuilder);
            UserConfig.Build(modelBuilder);
            UserRoleConfig.Build(modelBuilder);
            UserTokenConfig.Build(modelBuilder);
            UserTokenStorageConfig.Build(modelBuilder);
            UserUsedPasswordConfig.Build(modelBuilder);
            UserGeolocationConfig.Build(modelBuilder);
            GeographicalDistanceConfig.Build(modelBuilder);
        }
    }
}
