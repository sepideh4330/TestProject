using System;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Entities.Base
{
    public abstract class IdentityAuditableEntity
    {
        public virtual Guid Id { get; set; }

        public virtual Guid? CreatorIdentityId { get; set; }

        public virtual User CreatorIdentity { get; set; }

        public virtual DateTimeOffset? CreatedDateTimeOn { get; set; }

        public virtual string CreatorIdentityIp { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}