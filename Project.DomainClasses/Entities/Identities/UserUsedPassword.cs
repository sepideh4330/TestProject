using System;
using Project.DomainClasses.Entities.Base;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// کلمه عبور های استفاده شده توسط کاربران
    /// </summary>
    public class UserUsedPassword : IdentityAuditableEntity, IAuditableEntity
    {
        /// <summary>
        /// هش کلمه عبوری که کاربر استفاده کرده است
        /// </summary>
        public virtual string HashedPassword { get; set; }

        /// <summary>
        /// شناسه کاربری که کلمه عبور را وارد کرده است
        /// </summary>
        public virtual Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}