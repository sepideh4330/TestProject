using System;

namespace Project.DomainClasses.Entities.Base
{
    public abstract class PrimaryLogCreatedWithoutIdentityAuditableEntity
    {
        public virtual Guid Id { get; set; }

        public virtual DateTimeOffset? CreatedDateTimeOn { get; set; }

        public virtual string CreatorIp { get; set; }

        public virtual byte[] RowVersion { get; set; }

        public virtual long OrderRow { get; set; }
    }
}