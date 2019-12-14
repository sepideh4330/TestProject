using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum GroupCategory : short
    {
        /// <summary>
        /// مدیریت کاربران
        /// </summary>
        [Display(Name = "مدیریت کاربران")]
        UserManagement = 100,

        /// <summary>
        /// نصب انبوه
        /// </summary>
        [Display(Name = "نصب انبوه")]
        MassInstallation = 200,

        /// <summary>
        /// بازخرید
        /// </summary>
        [Display(Name = "بازخرید")]
        Redemption = 300,

        /// <summary>
        /// پشتیبانی
        /// </summary>
        [Display(Name = "پشتیبانی")]
        Support = 400,

        /// <summary>
        /// فروش
        /// </summary>
        [Display(Name = "فروش")]
        Sale = 500,

        /// <summary>
        /// مالی
        /// </summary>
        [Display(Name = "مالی")]
        Financial = 600,

        /// <summary>
        /// انبار و لجستیک
        /// </summary>
        [Display(Name = "انبار و لجستیک")]
        WarehouseAndLogestic = 700,

        /// <summary>
        /// انبار و لجستیک
        /// </summary>
        [Display(Name = "ارزیابی و عملکرد")]
        PerformanceEvaluation = 800,

        /// <summary>
        /// تنظیمات پایه
        /// </summary>
        [Display(Name = "تنظیمات پایه")]
        BasicSetting = 900,

        /// <summary>
        /// پروفایل کاربری
        /// </summary>
        [Display(Name = "پروفایل کاربری")]
        UserProfile = 1000,

        /// <summary>
        /// عمومی
        /// </summary>
        [Display(Name = "عمومی")]
        General = 1100,

        /// <summary>
        /// مدیریت کل
        /// </summary>
        [Display(Name = "مدیریت کل")]
        Admin = 1200,
    }
}
