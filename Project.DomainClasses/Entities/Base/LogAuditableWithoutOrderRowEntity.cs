using System;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Entities.Base
{
    public abstract class LogAuditableWithoutOrderRowEntity
    {
        public virtual Guid Id { get; set; }

        public virtual Guid CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual DateTimeOffset? CreatedDateTimeOn { get; set; }

        public virtual string CreatorIp { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}