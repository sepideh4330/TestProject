using System;

namespace Project.DomainClasses.Entities.Base
{
    public abstract class IdAuditableEntity
    {
        public virtual Guid Id { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}