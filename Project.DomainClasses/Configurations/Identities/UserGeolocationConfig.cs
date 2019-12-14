using Microsoft.EntityFrameworkCore;
using Project.Common.DataAnnotationSettings.General;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
    public static class UserGeolocationConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGeolocation>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("UserGeolocations", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.UserGeolocationUsers)
                    .HasForeignKey(d => d.UserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entityTypeBuilder.Property(d => d.Latitude).IsRequired().HasMaxLength(GeneralMaxLength.Latitude);
                entityTypeBuilder.Property(d => d.Longitude).IsRequired().HasMaxLength(GeneralMaxLength.Longitude);
            });
        }
    }
}
