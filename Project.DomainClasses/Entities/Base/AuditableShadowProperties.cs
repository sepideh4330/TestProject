using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Common.DataAnnotationSettings.General;
using Project.Common.Extensions;
using Project.Common.Utilities.SequentialGuid;

namespace Project.DomainClasses.Entities.Base
{
    public static class AuditableShadowProperties
    {
        public static readonly Func<object, string> EFPropertyOrderRow =
                                        entity => EF.Property<string>(entity, OrderRow);
        public static readonly string OrderRow = nameof(OrderRow);

        public static readonly Func<object, string> EFPropertyCreatorIp =
                                        entity => EF.Property<string>(entity, CreatorIp);
        public static readonly string CreatorIp = nameof(CreatorIp);

        public static readonly Func<object, string> EFPropertyCreatorIdentityIp =
                                        entity => EF.Property<string>(entity, CreatorIdentityIp);
        public static readonly string CreatorIdentityIp = nameof(CreatorIdentityIp);

        public static readonly Func<object, string> EFPropertyCreatedByIp =
                                        entity => EF.Property<string>(entity, CreatedByIp);
        public static readonly string CreatedByIp = nameof(CreatedByIp);

        public static readonly Func<object, string> EFPropertyModifiedByIp =
                                        entity => EF.Property<string>(entity, ModifiedByIp);
        public static readonly string ModifiedByIp = nameof(ModifiedByIp);

        public static readonly Func<object, Guid?> EFPropertyCreatedByUserId =
                                        entity => EF.Property<Guid?>(entity, CreatedByUserId);
        public static readonly string CreatedByUserId = nameof(CreatedByUserId);

        public static readonly Func<object, Guid?> EFPropertyCreatorIdentityId =
                                        entity => EF.Property<Guid?>(entity, CreatorIdentityId);
        public static readonly string CreatorIdentityId = nameof(CreatorIdentityId);

        public static readonly Func<object, Guid?> EFPropertyCreatorId =
                                        entity => EF.Property<Guid?>(entity, CreatorId);
        public static readonly string CreatorId = nameof(CreatorId);

        public static readonly Func<object, Guid?> EFPropertyModifiedByUserId =
                                        entity => EF.Property<Guid?>(entity, ModifiedByUserId);
        public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);

        public static readonly Func<object, DateTimeOffset?> EFPropertyCreatedDateTimeOn =
                                        entity => EF.Property<DateTimeOffset?>(entity, CreatedDateTimeOn);
        public static readonly string CreatedDateTimeOn = nameof(CreatedDateTimeOn);

        public static readonly Func<object, DateTimeOffset?> EFPropertyModifiedDateTimeOn =
                                        entity => EF.Property<DateTimeOffset?>(entity, ModifiedDateTimeOn);
        public static readonly string ModifiedDateTimeOn = nameof(ModifiedDateTimeOn);

        public static readonly Func<object, byte[]> EFPropertyRowVersion =
                                        entity => EF.Property<byte[]>(entity, RowVersion);
        public static readonly string RowVersion = nameof(RowVersion);

        public static readonly Func<object, Guid> EFPropertyId =
                                        entity => EF.Property<Guid>(entity, Id);
        public static readonly string Id = nameof(Id);

        public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model
                                                   .GetEntityTypes()
                                                   .Where(e => typeof(IAuditableEntity).IsAssignableFrom(e.ClrType)))
            {
                var entityTypeBuilder = modelBuilder.Entity(entityType.ClrType);

                if (entityTypeBuilder.Metadata.FindProperty(OrderRow) != null)
                {
                    entityTypeBuilder
                        .Property<long>(OrderRow)
                        .IsRequired()
                        .UseSqlServerIdentityColumn();
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatedByIp) != null)
                {
                    entityTypeBuilder
                        .Property<string>(CreatedByIp)
                        .IsRequired()
                        .HasMaxLength(GeneralMaxLength.Ip);
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatorIp) != null)
                {
                    entityTypeBuilder
                        .Property<string>(CreatorIp)
                        .IsRequired()
                        .HasMaxLength(GeneralMaxLength.Ip);
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatorIdentityIp) != null)
                {
                    entityTypeBuilder
                        .Property<string>(CreatorIdentityIp)
                        .IsRequired()
                        .HasMaxLength(GeneralMaxLength.Ip);
                }
                if (entityTypeBuilder.Metadata.FindProperty(RowVersion) != null)
                {
                    entityTypeBuilder
                        .Property<byte[]>(RowVersion)
                        .IsRequired()
                        .IsRowVersion();
                }
                if (entityTypeBuilder.Metadata.FindProperty(ModifiedByIp) != null)
                {
                    entityTypeBuilder
                        .Property<string>(ModifiedByIp)
                        .IsRequired(false)
                        .HasMaxLength(GeneralMaxLength.Ip);
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatedByUserId) != null)
                {
                    entityTypeBuilder
                        .Property<Guid?>(CreatedByUserId);
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatorIdentityId) != null)
                {
                    entityTypeBuilder
                        .Property<Guid?>(CreatorIdentityId);
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatorId) != null)
                {
                    entityTypeBuilder
                        .Property<Guid>(CreatorId);
                }
                if (entityTypeBuilder.Metadata.FindProperty(ModifiedByUserId) != null)
                {
                    entityTypeBuilder
                        .Property<Guid?>(ModifiedByUserId);
                }
                if (entityTypeBuilder.Metadata.FindProperty(CreatedDateTimeOn) != null)
                {
                    entityTypeBuilder
                        .Property<DateTimeOffset?>(CreatedDateTimeOn)
                        .IsRequired();
                }
                if (entityTypeBuilder.Metadata.FindProperty(ModifiedDateTimeOn) != null)
                {
                    entityTypeBuilder
                        .Property<DateTimeOffset?>(ModifiedDateTimeOn)
                        .IsRequired(false);
                }
                if (entityTypeBuilder.Metadata.FindProperty(Id) != null)
                {
                    entityTypeBuilder
                        .HasKey(Id);
                }
            }
        }
        public static void SetAuditableEntiTypeopertyValues(
            this ChangeTracker changeTracker,
            IHttpContextAccessor httpContextAccessor, Guid? ionicUserId = null)
        {
            var httpContext = httpContextAccessor?.HttpContext;
            var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();
            var userIp = httpContext?.Connection?.RemoteIpAddress?.ToString();
            if (string.IsNullOrEmpty(userIp))
            {
                userIp = "::1";
            }
            var now = DateTimeOffset.UtcNow.IranStandardTimeNow();
            var userId = ionicUserId ?? GetUserId(httpContext);

            var modifiedEntries = changeTracker.Entries()
                                               .Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                SetEntityEntryValue<DateTimeOffset?>(modifiedEntry, ModifiedDateTimeOn, now);
                SetEntityEntryValue<string>(modifiedEntry, ModifiedByIp, userIp);
                SetEntityEntryValue<Guid?>(modifiedEntry, ModifiedByUserId, userId);
            }

            var addedEntries = changeTracker.Entries()
                                            .Where(x => x.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                SetEntityEntryValue<DateTimeOffset?>(addedEntry, CreatedDateTimeOn, now);
                SetEntityEntryValue<string>(addedEntry, CreatedByIp, userIp);
                SetEntityEntryValue<string>(addedEntry, CreatorIp, userIp);
                SetEntityEntryValue<string>(addedEntry, CreatorIdentityIp, userIp);
                SetEntityEntryValue<Guid?>(addedEntry, CreatedByUserId, userId);
                SetEntityEntryValue<Guid?>(addedEntry, CreatorIdentityId, userId);
                SetEntityEntryValue<Guid?>(addedEntry, CreatorId, userId);
                SetEntityEntryValue<Guid>(addedEntry, Id, SequentialGuidGenerator.NewSequentialGuid());
            }
        }

        private static void SetEntityEntryValue<T>(EntityEntry entityEntry, string propertyName, T value)
        {
            if (entityEntry.Metadata.FindProperty(propertyName) == null)
            {
                return;
            }
            entityEntry.Property(propertyName).CurrentValue = value;
        }
        private static Guid? GetUserId(HttpContext httpContext)
        {
            Guid? userId = null;
            var userIdValue = httpContext?.User?.Identity?.GetUserId();
            if (!string.IsNullOrWhiteSpace(userIdValue))
            {
                userId = Guid.Parse(userIdValue);
            }
            return userId;
        }
    }
}
