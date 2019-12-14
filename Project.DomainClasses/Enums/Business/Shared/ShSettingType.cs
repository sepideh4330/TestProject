using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    public enum ShSettingType : short
    {
        /// <summary>
        /// عددی
        /// </summary>
        [Display(Name = "عددی")]
        Number = 100,

        /// <summary>
        /// متنی
        /// </summary>
        [Display(Name = "متنی")]
        Text = 200,

        /// <summary>
        /// دقیقه
        /// </summary>
        [Display(Name = "دقیقه")]
        Minutes = 300,

        /// <summary>
        /// گرفتن کاربر
        /// </summary>
        [Display(Name = "گرفتن کاربر")]
        Users = 400,

        /// <summary>
        /// بله یا خیر بودن مقدار
        /// </summary>
        [Display(Name = "بله یا خیر بودن مقدار")]
        Boolean = 500,

        /// <summary>
        /// مقدار پولی
        /// </summary>
        [Display(Name = "مقدار پولی")]
        Money = 600,

        /// <summary>
        /// ویرایشگر
        /// </summary>
        [Display(Name = "ویرایشگر")]
        Editor = 700,

        /// <summary>
        /// زمان
        /// </summary>
        [Display(Name = "زمان")]
        Time = 800,
    }
}
