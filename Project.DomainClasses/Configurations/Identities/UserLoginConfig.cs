using Microsoft.EntityFrameworkCore;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserLoginConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserLogins", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.Logins)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}