using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Project.DomainClasses.Entities.Base;
using Project.DomainClasses.Enums.Business.Shared;
using Project.DomainClasses.Enums.Identities;

namespace Project.DomainClasses.Entities.Identities
{
    public class User : IdentityUser<Guid>, IIdentityCreatedManagerAuditableEntity, IAuditableEntity
    {
        public User()
        {
            #region Identities

            UserChangeLogs = new List<UserChangeLog>();
            CreatedUserChangeLogs = new List<UserChangeLog>();
            UserUsedPasswords = new HashSet<UserUsedPassword>();
            UserTokens = new HashSet<UserToken>();
            UserTokenStorages = new HashSet<UserTokenStorage>();
            CreatedUserUsedPasswords = new List<UserUsedPassword>();
            CreatedUserTokenStorages = new List<UserTokenStorage>();
            Groups = new List<Group>();
            GroupRoles = new List<GroupRole>();
            GroupChangeLogs = new List<GroupChangeLog>();
            Roles = new List<UserRole>();
            UserGeolocationUsers = new List<UserGeolocation>();
            Users = new List<GeographicalDistance>();
            //UserShCities = new List<UserShCity>();

            #endregion

        }
        /// <summary>
        /// نام کاربر
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی کاربر
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// نام کامل
        /// نکته : این فیلد در دیتابیس قرار نمی گیرد
        /// </summary>
        public string FullName
        {
            get
            {
                var displayName = $"{FirstName} {LastName}";
                return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
            }
        }

        /// <summary>
        /// وضعیت فعلی کاربر
        /// </summary>
        public virtual UserStatus UserStatus { get; set; }

        public virtual Guid? GroupId { get; set; }

        public virtual Group Group { get; set; }

        /// <summary>
        /// برای بحث Token
        /// </summary>
        public virtual string SerialNumber { get; set; }

        /// <summary>
        /// تاریخ آخرین بازدید از سایت
        /// </summary>
        public virtual DateTimeOffset? LastVisitDateTimeOn { get; set; }

        /// <summary>
        /// تاریخ آخرین فعالیت در سایت
        /// </summary>
        public virtual DateTimeOffset? LastActivityDateTimeOn { get; set; }

        /// <summary>
        /// تاریخ آخرین ورود به سایت
        /// </summary>
        public virtual DateTimeOffset? LastLoginDateTimeOn { get; set; }

        /// <summary>
        /// تاریخ پایان اعتبار کد فعال سازی ایمیل
        /// </summary>
        public virtual DateTimeOffset? EmailTokenLifespanDateTimeOn { get; set; }

        /// <summary>
        /// کد فعال سازی ایمیل
        /// </summary>
        public virtual string EmailToken { get; set; }


        #region Identities

        public virtual ICollection<GeographicalDistance> Users { get; set; }

        public virtual ICollection<GroupChangeLog> GroupChangeLogs { get; set; }

        public virtual ICollection<UserChangeLog> CreatedUserChangeLogs { get; set; }

        public virtual ICollection<UserChangeLog> UserChangeLogs { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<GroupRole> GroupRoles { get; set; }

        public virtual ICollection<UserUsedPassword> UserUsedPasswords { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }

        public virtual ICollection<UserTokenStorage> UserTokenStorages { get; set; }

        public virtual ICollection<UserUsedPassword> CreatedUserUsedPasswords { get; set; }

        public virtual ICollection<UserTokenStorage> CreatedUserTokenStorages { get; set; }

        public virtual ICollection<UserGeolocation> UserGeolocationUsers { get; set; }

        //public virtual ICollection<UserShCity> UserShCities { get; set; }

        #endregion


        #region IIdentityCreatedManagerAuditableEntity

        /// <summary>
        /// آی پی کسی که کاربر را ایجاد کرده است
        /// </summary>
        public virtual string CreatorIdentityIp { get; set; }

        /// <summary>
        /// شناسه کسی که کاربر را ایجاد کرده است
        /// </summary>
        public virtual Guid? CreatorIdentityId { get; set; }

        public virtual User CreatorIdentity { get; set; }

        public virtual ICollection<User> CreatedUsers { get; set; }

        /// <summary>
        /// تاریج ایجاد کاربر
        /// </summary>
        public virtual DateTimeOffset? CreatedDateTimeOn { get; set; }

        /// <summary>
        /// برای همزمانی
        /// </summary>
        public virtual byte[] RowVersion { get; set; }

        #endregion
    }
}