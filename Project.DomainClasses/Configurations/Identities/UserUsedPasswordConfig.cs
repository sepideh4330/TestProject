using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserUsedPasswordConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserUsedPassword>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserUsedPasswords", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.CreatorIdentity)
                    .WithMany(d => d.CreatedUserUsedPasswords)
                    .HasForeignKey(d => d.CreatorIdentityId);
                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.UserUsedPasswords);

                entityTypeBuilder.Property(d => d.HashedPassword).HasMaxLength(450).IsRequired();
            });
        }
    }
}