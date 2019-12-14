using System.Collections.Generic;
using System.Security.Claims;

namespace Project.ServiceLayer.Services.Helper
{
    public class JwtTokensData
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string RefreshTokenSerial { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}
