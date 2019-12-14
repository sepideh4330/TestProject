
using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserTokenConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToken>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserTokens", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.UserTokens)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}