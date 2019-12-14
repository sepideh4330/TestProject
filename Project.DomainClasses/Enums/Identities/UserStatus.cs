using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Identities
{
    public enum UserStatus : short
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

        /// <summary>
        /// اخراج شده
        /// </summary>
        [Display(Name = "اخراج شده")]
        Fired = 300,

        /// <summary>
        /// منتظر تایید ایمیل
        /// </summary>
        [Display(Name = "منتظر تایید ایمیل")]
        WaitingConfirmationEmail = 400,
    }
}
