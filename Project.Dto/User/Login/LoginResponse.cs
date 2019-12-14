using System;
using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.Login
{
    public class LoginResponse : DtoResponse
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }

        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }
    }
}