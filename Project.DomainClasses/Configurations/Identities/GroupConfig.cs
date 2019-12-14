using Microsoft.EntityFrameworkCore;
using Project.Common.DataAnnotationSettings.Identities.Group;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class GroupConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Groups", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.CreatorIdentity)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(d => d.CreatorIdentityId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entityTypeBuilder.Property(d => d.Description).IsRequired(false).HasMaxLength(GroupMaxLength.Description);
                entityTypeBuilder.Property(d => d.NameFa).IsRequired().HasMaxLength(GroupMaxLength.Name);
                entityTypeBuilder.Property(d => d.NameEn).IsRequired().HasMaxLength(GroupMaxLength.Name);
                entityTypeBuilder.Property(d => d.GroupType).IsRequired();
                entityTypeBuilder.Property(d => d.GroupStatus).IsRequired();
                entityTypeBuilder.Property(d => d.GroupCategory).IsRequired();

                #region Base

                //entityTypeBuilder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();
                //entityTypeBuilder.Property(d => d.CreatedDateTimeOn).IsRequired();
                //entityTypeBuilder.Property(d => d.CreatedByIp).IsRequired().HasMaxLength(GeneralMaxLength.Ip);

                #endregion

            });
        }
    }
}