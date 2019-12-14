using System;
using Project.DomainClasses.Entities.Base;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// نقش هایی که برای هر گروه در نظر گرفته می شود
    /// </summary>
    public class GroupRole : IdentityAuditableEntity, IAuditableEntity
    {
        /// <summary>
        /// شناسه نقش
        /// </summary>
        public virtual Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        /// <summary>
        /// شناسه گروه
        /// </summary>
        public virtual Guid GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}