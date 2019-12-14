using System;
using Project.Common.Utilities.DtoHelper;

namespace Project.Dto.User.ConfirmUserRules.ConfrimRules
{
    public class ConfirmUserRulesResponse : DtoResponse
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }

        public Guid UserId { get; set; }

        public string AvatarId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string GroupName { get; set; }

        public string[] Roles { get; set; }

        public string SignatureId { get; set; }
    }
}
