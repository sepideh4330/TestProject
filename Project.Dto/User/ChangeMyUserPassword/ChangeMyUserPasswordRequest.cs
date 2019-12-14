using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Dto.User.ChangeMyUserPassword
{
    public class ChangeMyUserPasswordRequest
    {
        [Required(ErrorMessage = "شناسه کاربر ارسالی برای تغییر کلمه عبور نامعتبر می باشد")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "کلمه عبور قبلی را وارد کنید")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "کلمه عبور جدید را وارد کنید")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "تکرار کلمه عبور جدید را وارد کنید")]
        [Compare("NewPassword", ErrorMessage = "تکرار کلمه عبور وارد شده با کلمه عبور یکسان نمی باشد")]
        public string ConfirmNewPassword { get; set; }
    }
}
