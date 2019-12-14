using System;

namespace Project.DomainClasses.Entities.Base
{
    public abstract class IdLogAuditableEntity
    {
        public virtual Guid Id { get; set; }

        public virtual byte[] RowVersion { get; set; }

        public virtual long OrderRow { get; set; }
    }
}