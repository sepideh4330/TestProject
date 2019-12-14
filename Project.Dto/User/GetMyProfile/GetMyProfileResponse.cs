using System;
using Project.Common.Utilities.DtoHelper;
using Project.DomainClasses.Enums.Business.Shared;

namespace Project.Dto.User.GetMyProfile
{
    public class GetMyProfileResponse : DtoResponse
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
