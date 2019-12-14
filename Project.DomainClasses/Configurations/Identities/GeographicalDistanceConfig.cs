using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project.Common.DataAnnotationSettings.General;
using Project.Common.DataAnnotationSettings.Identities.User;
using Project.Common.Helpers;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Configurations.Identities
{
     public static class GeographicalDistanceConfig
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeographicalDistance>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("GeographicalDistances", Schemas.Identity);

                entityTypeBuilder.HasOne(d => d.User)
                    .WithMany(d => d.Users)
                    .HasForeignKey(d => d.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entityTypeBuilder.Property(e => e.Calculation).IsRequired();
                #region Base

                //entityTypeBuilder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();
                //entityTypeBuilder.Property(d => d.CreatedDateTimeOn).IsRequired();
                //entityTypeBuilder.Property(d => d.CreatedByIp).IsRequired().HasMaxLength(GeneralMaxLength.Ip);

                #endregion

            });
        }
    }
}
