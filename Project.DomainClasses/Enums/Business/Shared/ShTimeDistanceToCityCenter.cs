using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    /// <summary>
    /// فاصله زمانی تا مرکز شهر
    /// </summary>
    public enum ShTimeDistanceToCityCenter : short
    {
        /// <summary>
        /// نامشخص 
        /// </summary>
        [Display(Name = "نامشخص")]
        Unknown = 100,

        /// <summary>
        /// 12 ساعت بعد 
        /// </summary>
        [Display(Name = "12 ساعت بعد")]
        TwelveHoursLater = 200,

        /// <summary>
        /// 24 ساعت بعد 
        /// </summary>
        [Display(Name = "24 ساعت بعد")]
        TwentyFourHoursLater = 300,

        /// <summary>
        /// 36 ساعت بعد 
        /// </summary>
        [Display(Name = "36 ساعت بعد")]
        ThirtySixFourHoursLater = 400,

        /// <summary>
        /// 48 ساعت بعد 
        /// </summary>
        [Display(Name = "48 ساعت بعد")]
        FortyEightHoursLater = 500,

        /// <summary>
        /// 72 ساعت بعد 
        /// </summary>
        [Display(Name = "72 ساعت بعد")]
        SeventyTwoFourHoursLater = 600,

        /// <summary>
        /// 96 ساعت بعد 
        /// </summary>
        [Display(Name = "96 ساعت بعد")]
        NintySixFourHoursLater = 700,
    }
}
