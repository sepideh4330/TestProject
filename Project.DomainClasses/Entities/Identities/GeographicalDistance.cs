using System;
using Project.DomainClasses.Entities.Base;

namespace Project.DomainClasses.Entities.Identities
{
    public class GeographicalDistance : PrimaryCreatedWithoutIdentityAuditableEntity, IAuditableEntity
    {
        public virtual Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual double Calculation { get; set; }
    }
}
