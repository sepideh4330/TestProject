using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class RoleClaimConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleClaim>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("RoleClaims", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.Role)
                    .WithMany(d => d.Claims)
                    .HasForeignKey(d => d.RoleId);
            });
        }
    }
}
