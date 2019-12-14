using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class RoleConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Roles", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.ReferenceRole)
                    .WithMany(d => d.Roles)
                    .HasForeignKey(d => d.ReferenceRoleId)
                    .IsRequired(false);

                entityTypeBuilder.Property(d => d.RoleType).IsRequired().HasColumnName("Type");
                entityTypeBuilder.Property(d => d.RoleCategory).IsRequired().HasColumnName("Category");
                entityTypeBuilder.Property(d => d.NameFa).IsRequired().HasMaxLength(256);
                entityTypeBuilder.Property(d => d.Description).IsRequired().HasMaxLength(512);

                #region Base

                //entityTypeBuilder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();

                #endregion
            });
        }
    }
}