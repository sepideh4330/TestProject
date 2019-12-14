using System;
using Microsoft.AspNetCore.Identity;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// Clain کاربران
    /// </summary>
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public virtual User User { get; set; }
    }
}