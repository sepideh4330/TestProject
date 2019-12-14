using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum UserType : short
    {
        /// <summary>
        /// کاربر عادی
        /// </summary>
        [Display(Name = "کاربر عادی")]
        Normal = 100,

        /// <summary>
        /// کاربر سیستمی
        /// </summary>
        [Display(Name = "کاربر سیستمی")]
        System = 200
    }
}
