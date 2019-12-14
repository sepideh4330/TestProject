using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.RefreshToken
{
    public class RefreshTokenResponse : DtoResponse
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }
    }
}