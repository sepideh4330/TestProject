using System;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Entities.Base
{
    public interface IIdentityCreatedManagerAuditableEntity
    {
        string CreatorIdentityIp { get; set; }
        Guid? CreatorIdentityId { get; set; }
        User CreatorIdentity { get; set; }
        DateTimeOffset? CreatedDateTimeOn { get; set; }
        byte[] RowVersion { get; set; }
    }
}