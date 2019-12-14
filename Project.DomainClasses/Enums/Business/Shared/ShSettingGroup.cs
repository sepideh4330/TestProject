using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    /// <summary>
    /// گروه تنظیمات
    /// </summary>
    public enum ShSettingGroup : short
    {
        /// <summary>
        /// اپلیکیشن مبین یار
        /// </summary>
        [Display(Name = "تنظیمات اپلیکیشن مبین یار")]
        ProjectApplicationSetting = 100,

        /// <summary>
        /// تنظیمات ورژن های مبین یار
        /// </summary>
        [Display(Name = "تنظیمات ورژن های مبین یار")]
        ProjectVersionsSetting = 200,

        /// <summary>
        /// تنظیمات قوانین مبین یار
        /// </summary>
        [Display(Name = "تنظیمات قوانین مبین یار")]
        ProjectRolesSetting = 300,

        /// <summary>
        /// تنظیمات ربات ها
        /// </summary>
        [Display(Name = "تنظیمات ربات ها")]
        RobotsSetting = 400,

        /// <summary>
        /// تنظیمات دسترسی Crm
        /// </summary>
        [Display(Name = "تنظیمات دسترسی Crm")]
        CrmAccessSetting = 500,

        /// <summary>
        /// تنظیمات دسترسی اتصال
        /// </summary>
        [Display(Name = "تنظیمات دسترسی اتصال")]
        ConnectionAccessSetting = 600,

        /// <summary>
        /// تنظیمات پیامک ها
        /// </summary>
        [Display(Name = "تنظیمات پیامک ها")]
        SmsSetting = 700,

        /// <summary>
        /// تنظیمات پارامترهای داینامیک
        /// </summary>
        [Display(Name = "تنظیمات پارامترهای داینامیک")]
        DynamicParametersSetting = 800,

        /// <summary>
        /// تنظیمات مدیریت تیکت های بازخرید
        /// </summary>
        [Display(Name = "تنظیمات مدیریت تیکت های بازخرید")]
        RedemptionTicketManagementSetting = 900,

        /// <summary>
        /// تنظیمات مدیریت تجهیزات بازخرید
        /// </summary>
        [Display(Name = "تنظیمات مدیریت تجهیزات بازخرید")]
        RedemptionEquipmentManagementSetting = 1000,

        /// <summary>
        /// تنظیمات مالی بازخرید
        /// </summary>
        [Display(Name = "تنظیمات مالی بازخرید")]
        RedemptionFinancialSetting = 1100,

        /// <summary>
        /// تنظیمات مدیریت تیکت های نصب انبوه
        /// </summary>
        [Display(Name = "تنظیمات مدیریت تیکت های نصب انبوه")]
        MassInstallationTicketManagementSetting = 1200,

        /// <summary>
        /// تنظیمات مالی نصب انبوه
        /// </summary>
        [Display(Name = "تنظیمات مالی نصب انبوه")]
        MassInstallationFinancialSetting = 1300,

        /// <summary>
        /// تنظیمات پستی
        /// </summary>
        [Display(Name = "تنظیمات پستی")]
        PostalSetting = 1400,

        /// <summary>
        /// تنظیمات بازگشت وجه
        /// </summary>
        [Display(Name = "تنظیمات بازگشت وجه")]
        MoneyBackSetting = 1500,

        /// <summary>
        /// تنظیمات لاگ سیستم
        /// </summary>
        [Display(Name = "تنظیمات لاگ سیستم")]
        SystemLogSetting = 1600,
    }
}
