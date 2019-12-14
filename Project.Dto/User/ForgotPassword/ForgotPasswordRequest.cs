using Project.Common.Extensions;
using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.ForgotPassword
{
    public class ForgotPasswordRequest : DtoCaptcha
    {
        private string _userName;

        public string UserName
        {
            get => _userName.UnMask();
            set => _userName = value;
        }
    }
}
