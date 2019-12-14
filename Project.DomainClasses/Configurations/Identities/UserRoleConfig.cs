using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserRoleConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserRoles", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.Role)
                    .WithMany(d => d.Users)
                    .HasForeignKey(d => d.RoleId);
                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.Roles)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}