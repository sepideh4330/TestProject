using Microsoft.EntityFrameworkCore;
using Project.Common.DataAnnotationSettings.General;
using Project.Common.DataAnnotationSettings.Identities.User;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Users", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.Group)
                    .WithMany(d => d.Users)
                    .HasForeignKey(d => d.GroupId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                entityTypeBuilder.HasOne(d => d.CreatorIdentity)
                    .WithMany(d => d.CreatedUsers)
                    .HasForeignKey(d => d.CreatorIdentityId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entityTypeBuilder.Property(e => e.LastVisitDateTimeOn).IsRequired(false);
                entityTypeBuilder.Property(e => e.LastActivityDateTimeOn).IsRequired(false);
                entityTypeBuilder.Property(e => e.LastLoginDateTimeOn).IsRequired(false);
                entityTypeBuilder.Property(e => e.EmailTokenLifespanDateTimeOn).IsRequired(false);
                entityTypeBuilder.Property(e => e.EmailToken).IsRequired(false).HasMaxLength(512);
                entityTypeBuilder.Property(e => e.PhoneNumber).HasMaxLength(GeneralStaticLength.PhoneNumber);
                entityTypeBuilder.Property(e => e.UserName).HasMaxLength(UserMaxLength.UserName).IsRequired();
                entityTypeBuilder.Property(e => e.SerialNumber).HasMaxLength(450);
                entityTypeBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(UserMaxLength.FirstName);
                entityTypeBuilder.Property(e => e.LastName).IsRequired().HasMaxLength(UserMaxLength.LastName);
                entityTypeBuilder.Property(e => e.UserStatus).HasColumnName("Status").IsRequired();
                entityTypeBuilder.Ignore(e => e.FullName);
                #region Base

                //entityTypeBuilder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();
                //entityTypeBuilder.Property(d => d.CreatedDateTimeOn).IsRequired();
                //entityTypeBuilder.Property(d => d.CreatedByIp).IsRequired().HasMaxLength(GeneralMaxLength.Ip);

                #endregion

            });
        }
    }
}