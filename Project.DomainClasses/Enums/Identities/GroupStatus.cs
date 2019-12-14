using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum GroupStatus : short
    {
        /// <summary>
        /// فعال
        /// </summary>
        [Display(Name = "فعال")]
        Active = 100,

        /// <summary>
        /// غیر فعال
        /// </summary>
        [Display(Name = "غیر فعال")]
        Inactive = 200,
    }
}
