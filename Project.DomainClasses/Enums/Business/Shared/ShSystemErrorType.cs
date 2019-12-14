using System.ComponentModel.DataAnnotations;

namespace Project.DomainClasses.Enums.Business.Shared
{
    public enum ShSystemErrorType : short
    {
        [Display(Name = "ربات دریافت")]
        RobotFetch = 100,
    }
}
