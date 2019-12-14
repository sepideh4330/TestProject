using Project.Common.Extensions;
using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.Login
{
    public class LoginRequest : DtoCaptcha
    {
        private string _userName;

        public string UserName
        {
            get => _userName.UnMask();
            set => _userName = value;
        }

        public string Password { get; set; }
    }
}
