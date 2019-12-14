using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserChangeLogConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChangeLog>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserChangeLogs", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.Creator)
                    .WithMany(d => d.CreatedUserChangeLogs)
                    .HasForeignKey(d => d.CreatorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.UserChangeLogs)
                    .HasForeignKey(d => d.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entityTypeBuilder.Property(d => d.Previous).IsRequired();
                entityTypeBuilder.Property(d => d.Current).IsRequired();
                entityTypeBuilder.Ignore(d => d.PreviousValue);
                entityTypeBuilder.Ignore(d => d.CurrentValue);

                #region Base

                //entityTypeBuilder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();
                //entityTypeBuilder.Property(d => d.CreatedDateTimeOn).IsRequired();
                //entityTypeBuilder.Property(d => d.CreatedByIp).IsRequired().HasMaxLength(GeneralMaxLength.Ip);

                #endregion
            });
        }
    }
}
