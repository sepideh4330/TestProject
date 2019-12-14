using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    public enum ShLogType : short
    {
        /// <summary>
        /// تیکت
        /// </summary>
        [Display(Name = "تیکت")]
        Ticket = 100,

        /// <summary>
        /// مودم
        /// </summary>
        [Display(Name = "مودم")]
        Modem = 200
    }
}
