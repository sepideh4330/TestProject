using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Dto.User.ChangeMyLocation
{
    public class ChangeMyLocationRequest
    {
        [Required(ErrorMessage = "شناسه کاربر ارسالی برای تغییر موقعیت جغرافیایی نامعتبر می باشد نامعتبر می باشد")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "عرض جغرافیایی وارد شده نامعتبر می باشد")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "طول جغرافیایی وارد شده نامعتبر می باشد")]
        public string Longitude { get; set; }
    }
}
