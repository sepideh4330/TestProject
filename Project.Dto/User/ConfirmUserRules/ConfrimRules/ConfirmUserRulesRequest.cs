using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Dto.User.ConfirmUserRules.ConfrimRules
{
    public class ConfirmUserRulesRequest 
    {
        [Required(ErrorMessage = "شناسه کاربر درخواستی برای تایید قوانین نامعتبر می باشد")]
        public Guid? Id { get; set; }
    }
}
