using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum GroupType : short
    {
        /// <summary>
        /// گروه عادی
        /// </summary>
        [Display(Name = "گروه عادی")]
        Normal = 100,

        /// <summary>
        /// گروه سیستمی
        /// </summary>
        [Display(Name = "گروه سیستمی")]
        System = 200
    }
}