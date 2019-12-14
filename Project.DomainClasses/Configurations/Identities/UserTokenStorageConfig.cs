using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserTokenStorageConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTokenStorage>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserTokenStorages", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.CreatorIdentity)
                    .WithMany(d => d.CreatedUserTokenStorages)
                    .HasForeignKey(d => d.CreatorIdentityId);
                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.UserTokenStorages)
                    .HasForeignKey(d => d.UserId);

                entityTypeBuilder.Property(d => d.RefreshTokenIdHash).HasMaxLength(450).IsRequired();
                entityTypeBuilder.Property(d => d.RefreshTokenIdHashSource).HasMaxLength(450).IsRequired(false);
            });
        }
    }
}