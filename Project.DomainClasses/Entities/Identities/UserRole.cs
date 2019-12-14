using System;
using Microsoft.AspNetCore.Identity;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// نقش کاربران
    /// </summary>
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}