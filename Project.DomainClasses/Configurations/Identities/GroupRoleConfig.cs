using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class GroupRoleConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupRole>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("GroupRoles", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.Role)
                    .WithMany(d => d.GroupRoles)
                    .HasForeignKey(d => d.RoleId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                entityTypeBuilder.HasOne(d => d.Group)
                    .WithMany(d => d.GroupRoles)
                    .HasForeignKey(d => d.GroupId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                entityTypeBuilder.HasOne(d => d.CreatorIdentity)
                    .WithMany(d => d.GroupRoles)
                    .HasForeignKey(d => d.CreatorIdentityId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                #region Base

                //entityTypeBuilder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();
                //entityTypeBuilder.Property(d => d.CreatedDateTimeOn).IsRequired();
                //entityTypeBuilder.Property(d => d.CreatedByIp).IsRequired().HasMaxLength(GeneralMaxLength.Ip);

                #endregion
            });
        }
    }
}