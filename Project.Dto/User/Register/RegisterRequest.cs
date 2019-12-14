using System;
using System.ComponentModel.DataAnnotations;
using Project.Common.DataAnnotationSettings.General;
using Project.Common.DataAnnotationSettings.Identities.User;
using Project.Common.Helpers;
using Project.DomainClasses.Enums.Business.Shared;

namespace Project.Dto.User.Register
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "نام کاربر را وارد نمایید")]
        [StringLength(UserMaxLength.FirstName, ErrorMessage = "نام کاربر باید حداقل 2 و حداکثر 50 کاراکتر باشد"
            , MinimumLength = UserMinLength.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی کاربر را وارد نمایید")]
        [StringLength(UserMaxLength.LastName, ErrorMessage = "نام خانوادگی کاربر باید حداقل 2 و حداکثر 120 کاراکتر باشد"
            , MinimumLength = UserMinLength.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [StringLength(GeneralMaxLength.Email, ErrorMessage = "ایمیل باید حداقل 5 و حداکثر 120 کاراکتر باشد"
            , MinimumLength = GeneralMinLength.Email)]
        [RegularExpression(Patterns.Email, ErrorMessage = "ایمیل وارد شده نامعتبر می باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = " کلمه عبور را وارد نمایید")]
        [StringLength(UserMaxLength.UserName, ErrorMessage = "کلمه عبور باید حداقل 2 و حداکثر 50 کاراکتر باشد"
            , MinimumLength = UserMinLength.UserName)]
        public string Password { get; set; }
    }
}
