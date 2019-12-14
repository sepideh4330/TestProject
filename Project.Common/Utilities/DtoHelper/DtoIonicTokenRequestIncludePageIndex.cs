using System.ComponentModel.DataAnnotations;

namespace Project.Common.Utilities.DtoHelper
{
    public abstract class DtoIonicTokenRequestIncludePageIndex
    {
        [Required(ErrorMessage = "توکن کاربر معتبر نمی باشد")]
        public string IonicToken { get; set; }

        [Required(ErrorMessage = "شماره صفحه معتبر نمی باشد")]
        public int? PageIndex { get; set; }
    }
}