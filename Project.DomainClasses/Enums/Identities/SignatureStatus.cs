using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum SignatureStatus : short
    {
        /// <summary>
        /// تایید شده
        /// </summary>
        [Display(Name = "تایید شده")]
        Confirmed = 100,

        /// <summary>
        /// ارسال نشده
        /// </summary>
        [Display(Name = "ارسال نشده")]
        NotSend = 200,

        /// <summary>
        /// در حال بررسی
        /// </summary>
        [Display(Name = "در حال بررسی")]
        InProgress = 300,

        /// <summary>
        /// رد شده
        /// </summary>
        [Display(Name = "رد شده")]
        Rejected = 400,
    }
}