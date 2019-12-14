using System;
using Microsoft.AspNetCore.Identity;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// توکن کاربران
    /// </summary>
    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; }
    }
}