using System;
using Project.DomainClasses.Entities.Base;

namespace Project.DomainClasses.Entities.Identities
{
    public class UserGeolocation : PrimaryCreatedWithoutIdentityAuditableEntity, IAuditableEntity
    {
        /// <summary>
        /// طول جغرافیایی
        /// </summary>
        public virtual string Latitude { get; set; }

        /// <summary>
        /// عرض جغرافیایی
        /// </summary>
        public virtual string Longitude { get; set; }

        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public virtual Guid? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
