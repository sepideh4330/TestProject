using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.DomainClasses.Entities.Base;

namespace Project.DomainClasses.Entities.Identities
{
    /// <summary>
    /// لاگ تغییرات گروه های کاربری
    /// </summary>
    public class GroupChangeLog : LogAuditableEntity, IAuditableEntity
    {
        /// <summary>
        /// مقدار قبلی
        /// </summary>
        internal string Previous { get; set; }

        [NotMapped]
        public JObject PreviousValue
        {
            get => JsonConvert.DeserializeObject<JObject>(Previous);
            set => Previous = JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// مقدار فعلی
        /// </summary>
        internal string Current { get; set; }

        [NotMapped]
        public JObject CurrentValue
        {
            get => JsonConvert.DeserializeObject<JObject>(Current);
            set => Current = JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// شناسه گروه کاربری
        /// </summary>
        public virtual Guid GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}