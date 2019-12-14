using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    public enum ShGender : short
    {
        /// <summary>
        /// زن 
        /// </summary>
        [Display(Name = "زن")]
        Female = 100,

        /// <summary>
        /// مرد
        /// </summary>
        [Display(Name = "مرد")]
        Man = 200,
    }
}