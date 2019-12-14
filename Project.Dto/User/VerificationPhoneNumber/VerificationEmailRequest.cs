using Project.Common.Extensions;
using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.VerificationPhoneNumber
{
    public class VerificationEmailRequest : DtoCaptcha
    {
        private string _userName;
        private string _verificationEmailToken;

        public string UserName
        {
            get => _userName.UnMask();
            set => _userName = value;
        }

        public string VerificationEmailToken
        {
            get => _verificationEmailToken.UnMask();
            set => _verificationEmailToken = value;
        }
    }
}
