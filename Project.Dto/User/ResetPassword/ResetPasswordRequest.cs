using Project.Common.Extensions;
using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.ResetPassword
{
    public class ResetPasswordRequest : DtoCaptcha
    {
        private string _userName;
        private string _resetPasswordToken;

        public string UserName
        {
            get => _userName.UnMask();
            set => _userName = value;
        }

        public string ResetPasswordToken
        {
            get => _resetPasswordToken.UnMask();
            set => _resetPasswordToken = value;
        }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }
    }
}
