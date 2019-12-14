using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    /// <summary>
    /// دسته بندی تنظیمات
    /// </summary>
    public enum ShSettingCategory : short
    {
        /// <summary>
        /// تنظیمات پایه
        /// </summary>
        [Display(Name = "تنظیمات پایه")]
        BaseSetting = 100,

        /// <summary>
        /// تنظیمات Crm مبین نت
        /// </summary>
        [Display(Name = "تنظیمات Crm مبین نت")]
        MobinnetCrmSetting = 200,

        /// <summary>
        /// تنظیمات پنل پیامکی
        /// </summary>
        [Display(Name = "تنظیمات پنل پیامکی")]
        SmsPanelSetting = 300,

        /// <summary>
        /// تنظیمات بازخرید
        /// </summary>
        [Display(Name = "تنظیمات بازخرید")]
        RedemptionSetting = 400,

        /// <summary>
        /// تنظیمات نصب انبوه
        /// </summary>
        [Display(Name = "تنظیمات نصب انبوه")]
        MassInstallationSetting = 500,

        /// <summary>
        /// تنظیمات پشتیبانی
        /// </summary>
        [Display(Name = "تنظیمات پشتیبانی")]
        SupportSetting = 600,
    }
}
