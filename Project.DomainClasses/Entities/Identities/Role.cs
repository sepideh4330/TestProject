using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Project.DomainClasses.Entities.Base;
using Project.DomainClasses.Enums.Identities;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// نقش های کاربری
    /// </summary>
    public class Role : IdentityRole<Guid>, IAuditableEntity
    {
        public Role()
        {
            Users = new List<UserRole>();
            Claims = new List<RoleClaim>();
            GroupRoles = new List<GroupRole>();
            Roles = new List<Role>();
        }

        /// <summary>
        /// توضیحات نقش گروه
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// نام فارسی نقش
        /// </summary>
        public virtual string NameFa { get; set; }

        /// <summary>
        /// نوع نقش
        /// </summary>
        public virtual RoleType RoleType { get; set; }

        /// <summary>
        /// دسته بندی نقش
        /// </summary>
        public virtual RoleCategory RoleCategory { get; set; }

        /// <summary>
        /// شناسه نقش وابسته
        /// </summary>
        public virtual Guid? ReferenceRoleId { get; set; }

        public virtual Role ReferenceRole { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }

        public virtual ICollection<RoleClaim> Claims { get; set; }

        public virtual ICollection<GroupRole> GroupRoles { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}