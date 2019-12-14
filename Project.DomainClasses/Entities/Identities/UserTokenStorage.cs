using System;
using Project.DomainClasses.Entities.Base;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// ورود کاربران بر اساس توکن
    /// </summary>
    public class UserTokenStorage : IdentityAuditableEntity, IAuditableEntity
    {
        /// <summary>
        /// توکن هش شده برای دسترسی به سیستم
        /// </summary>
        public virtual string AccessTokenHash { get; set; }

        /// <summary>
        /// مدت زمان دسترسی به سیستم بر اساس توکن
        /// </summary>
        public virtual DateTimeOffset AccessTokenExpiresDateTimeOn { get; set; }

        /// <summary>
        /// توکنی که با آن می تواند عملیات رفرش شدن توکن به صورت اتوماتیک انجام شود
        /// </summary>
        public virtual string RefreshTokenIdHash { get; set; }

        /// <summary>
        /// منبع توکنی که با آن می تواند عملیات رفرش شدن توکن به صورت اتوماتیک انجام شود 
        /// </summary>
        public virtual string RefreshTokenIdHashSource { get; set; }

        /// <summary>
        /// مدت زمان دسترسی به رفرش توکن
        /// </summary>
        public virtual DateTimeOffset RefreshTokenExpiresDateTimeOn { get; set; }

        /// <summary>
        /// شناسه کاربری که توکن متعلق به آن است
        /// </summary>
        public virtual Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
