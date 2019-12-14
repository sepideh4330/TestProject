using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum RoleType : short
    {
        /// <summary>
        /// مدیریت مودم نصب انبوه
        /// </summary>
        [Display(Name = "مدیریت مودم نصب انبوه")]
        MiModemManagement = 100,

        /// <summary>
        /// مدیریت سیم کارت نصب انبوه
        /// </summary>
        [Display(Name = "مدیریت سیم کارت نصب انبوه")]
        MiSimcartManagement = 200,

        /// <summary>
        /// انبارداری نصب انبوه
        /// </summary>
        [Display(Name = "انبارداری نصب انبوه")]
        MiStore = 300,

        /// <summary>
        /// مدیریت اطلاعات نصب انبوه
        /// </summary>
        [Display(Name = "مدیریت اطلاعات نصب انبوه")]
        MiInformationManagement = 400,

        /// <summary>
        /// لیست بازخرید شده ها
        /// </summary>
        [Display(Name = "لیست بازخرید شده ها")]
        ReRedemptionList = 500,

        /// <summary>
        /// مدیریت تیکت بازخرید
        /// </summary>
        [Display(Name = "مدیریت تیکت بازخرید")]
        ReTicketManagement = 600,

        /// <summary>
        /// امور مالی بازخرید در مالی
        /// </summary>
        [Display(Name = "امور مالی بازخرید در مالی")]
        ReFinancial = 700,

        /// <summary>
        /// انبارداری بازخرید
        /// </summary>
        [Display(Name = "انبارداری بازخرید")]
        ReStore = 800,

        /// <summary>
        /// مدیریت اطلاعات بازخرید
        /// </summary>
        [Display(Name = "مدیریت اطلاعات بازخرید")]
        ReInformationManagement = 900,

        /// <summary>
        /// نقش های مدیریت کاربران
        /// </summary>
        [Display(Name = "نقش های مدیریت کاربران")]
        UmRole = 1000,

        /// <summary>
        /// گروه های مدیریت کاربران
        /// </summary>
        [Display(Name = "گروه های مدیریت کاربران")]
        UmGroup = 1100,

        /// <summary>
        /// کاربران مدیریت کاربران
        /// </summary>
        [Display(Name = "کاربران مدیریت کاربران")]
        UmUser = 1200,

        /// <summary>
        /// پروفایل کاربران
        /// </summary>
        [Display(Name = "پروفایل کاربران")]
        Profile = 1300,

        /// <summary>
        /// صفحه اصلی مدیریت کاربران
        /// </summary>
        [Display(Name = "صفحه اصلی مدیریت کاربران")]
        UmHome = 1400,

        /// <summary>
        /// صفحه اصلی بازخرید
        /// </summary>
        [Display(Name = "صفحه اصلی بازخرید")]
        ReHome = 1500,

        /// <summary>
        /// صفحه اصلی نصب انبوه
        /// </summary>
        [Display(Name = "صفحه اصلی نصب انبوه")]
        MiHome = 1600,

        /// <summary>
        /// مدیریت تیکت نصب انبوه
        /// </summary>
        [Display(Name = "مدیریت تیکت نصب انبوه")]
        MiTicket = 1700,

        /// <summary>
        /// تنظیمات نصب انبوه در تنظیمات پایه
        /// </summary>
        [Display(Name = "تنظیمات نصب انبوه در تنظیمات پایه")]
        MiSetting = 1800,

        /// <summary>
        /// تنظیمات بازخرید در تنظیمات پایه
        /// </summary>
        [Display(Name = "تنظیمات بازخرید در تنظیمات پایه")]
        ReSetting = 1900,

        /// <summary>
        /// شهرها در تنظیمات پایه
        /// </summary>
        [Display(Name = "شهرها در تنظیمات پایه")]
        ShCity = 2000,

        /// <summary>
        /// لاگ عمومی در تنظیمات پایه
        /// </summary>
        [Display(Name = "لاگ عمومی در تنظیمات پایه")]
        ShLog = 2100,

        /// <summary>
        /// تنظیمات عمومی در تنظیمات پایه
        /// </summary>
        [Display(Name = "تنظیمات عمومی در تنظیمات پایه")]
        ShSetting = 2200,

        /// <summary>
        /// عمومی 
        /// </summary>
        [Display(Name = "عمومی")]
        General = 2300,

        /// <summary>
        /// ربات مغایرت نصب انبوه 
        /// </summary>
        [Display(Name = "ربات مغایرت نصب انبوه")]
        OppositeOfRobot = 2400,

        /// <summary>
        /// امور مالی نصب انبوه در مالی 
        /// </summary>
        [Display(Name = "امور مالی نصب انبوه در مالی")]
        FinancialDepartment = 2500,

        /// <summary>
        /// استان ها در تنظیمات پایه 
        /// </summary>
        [Display(Name = "استان ها در تنظیمات پایه")]
        ShProvince = 2600,

        /// <summary>
        /// مدیریت اطلاعات مدیریت کاربران 
        /// </summary>
        [Display(Name = "مدیریت اطلاعات مدیریت کاربران")]
        UmInformationManagement = 2700,

        /// <summary>
        /// صفحه اصلی پشتیبانی 
        /// </summary>
        [Display(Name = "صفحه اصلی پشتیبانی")]
        SuHome = 2800,

        /// <summary>
        /// صفحه اصلی فروش 
        /// </summary>
        [Display(Name = "صفحه اصلی فروش")]
        SaHome = 2900,

        /// <summary>
        /// صفحه اصلی مالی 
        /// </summary>
        [Display(Name = "صفحه اصلی مالی")]
        FiHome = 3000,

        /// <summary>
        /// صفحه اصلی انبار و لجستیک 
        /// </summary>
        [Display(Name = "صفحه اصلی انبار و لجستیک")]
        WlHome = 3100,

        /// <summary>
        /// انبار نصب انبوه در انبار و لجستیک 
        /// </summary>
        [Display(Name = "انبار نصب انبوه در انبار و لجستیک")]
        WlMassInstallationWarehouse = 3200,

        /// <summary>
        /// تیکت های پشتیبانی 
        /// </summary>
        [Display(Name = "تیکت های پشتیبانی")]
        SuTicket = 3300,

        /// <summary>
        /// مدیریت اطلاعات پشتیبانی 
        /// </summary>
        [Display(Name = "مدیریت اطلاعات پشتیبانی")]
        SuInformationManagement = 3400,

        /// <summary>
        /// صفحه اصلی ارزیابی عملکرد 
        /// </summary>
        [Display(Name = "صفحه اصلی ارزیابی عملکرد")]
        PeHome = 3500,

        /// <summary>
        /// دوره های ارزیابی عملکرد 
        /// </summary>
        [Display(Name = "دوره های آموزشی ارزیابی عملکرد")]
        PeCourse = 3600,

        /// <summary>
        /// تیکت های پستی نصب انبوه 
        /// </summary>
        [Display(Name = "تیکت های پستی نصب انبوه")]
        MiPostalTicket = 3700,

        /// <summary>
        /// نظرسنجی ارزیابی عملکرد 
        /// </summary>
        [Display(Name = "نظرسنجی ارزیابی عملکرد")]
        PeSurvey = 3800,

        /// <summary>
        /// تیکت فروش 
        /// </summary>
        [Display(Name = "تیکت فروش")]
        SaTicket = 3900,

        /// <summary>
        /// دوره آموزشی کاربر 
        /// </summary>
        [Display(Name = "دوره آموزشی کاربر")]
        PeUserCourse = 4000,

        /// <summary>
        /// تیکت های پستی انبار و لجستیک 
        /// </summary>
        [Display(Name = "تیکت های پستی انبار و لجستیک")]
        WlTicket = 4100,

        /// <summary>
        /// صفحه اصلی تنظیمات پایه 
        /// </summary>
        [Display(Name = "صفحه اصلی تنظیمات پایه")]
        BsHome = 4200,

        /// <summary>
        /// مدیریت اطلاعات انبار و لجستیک
        /// </summary>
        [Display(Name = "مدیریت اطلاعات انبار و لجستیک")]
        WlInformationManagement = 4300,

        /// <summary>
        /// اعلام تاخیرهای پشتیبانی
        /// </summary>
        [Display(Name = "اعلام تاخیرهای پشتیبانی")]
        SuDeclareDelay = 4400,

        /// <summary>
        /// تیکت های بازگشت پول انبار
        /// </summary>
        [Display(Name = "تیکت های بازگشت پول انبار")]
        SuMoneyBackTicketForWl = 4500,

        /// <summary>
        /// مدارک مشتریان فروش
        /// </summary>
        [Display(Name = "مدارک مشتریان فروش")]
        SaCustomerDocument = 4600,

        /// <summary>
        /// گزارشات نصب انبوه
        /// </summary>
        [Display(Name = "گزارشات نصب انبوه")]
        MiReport = 4700,
    }
}