using System.ComponentModel.DataAnnotations;

namespace Project.Common.Utilities.DtoHelper
{
    public abstract class DtoIonicTokenRequest
    {
        [Required(ErrorMessage = "توکن کاربر معتبر نمی باشد")]
        public string IonicToken { get; set; }
    }
}