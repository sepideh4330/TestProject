using System.Collections.Generic;
using Project.Common.Utilities.SequentialGuid;
using Project.DomainClasses.Entities.Base;
using Project.DomainClasses.Enums.Identities;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// گروه های کاربری
    /// </summary>
    public class Group : IdentityAuditableEntity, IAuditableEntity
    {
        public Group()
        {
            GroupRoles = new List<GroupRole>();
            GroupChangeLogs = new List<GroupChangeLog>();
            Users = new List<User>();
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }

        /// <summary>
        /// دسته ی گروه
        /// </summary>
        public virtual GroupCategory GroupCategory { get; set; }

        /// <summary>
        /// نوع گروه
        /// </summary>
        public virtual GroupType GroupType { get; set; }

        /// <summary>
        /// وضعیت گروه
        /// </summary>
        public virtual GroupStatus GroupStatus { get; set; }

        /// <summary>
        /// توضیحات گروه
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// نام فارسی گروه
        /// </summary>
        public virtual string NameFa { get; set; }

        /// <summary>
        /// نام انگلیسی گروه
        /// </summary>
        public virtual string NameEn { get; set; }

        public virtual ICollection<GroupRole> GroupRoles { get; set; }

        public virtual ICollection<GroupChangeLog> GroupChangeLogs { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}