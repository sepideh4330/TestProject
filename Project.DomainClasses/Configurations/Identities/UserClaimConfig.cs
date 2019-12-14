using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserClaimConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClaim>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserClaims", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.Claims)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}