using System;
using Microsoft.AspNetCore.Identity;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// ورود کاربران به سیستم
    /// </summary>
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual User User { get; set; }
    }
}