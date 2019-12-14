using AutoMapper;
using Project.DomainClasses.Entities.Identities;
using Project.DomainClasses.Enums.Identities;
using Project.Dto.User.ChangeMyLocation;
using Project.Dto.User.GetMyProfile;
using Project.Dto.User.Register;

namespace Project.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetMyProfileResponse>()
                .ReverseMap();

            CreateMap<RegisterRequest, User>()
                .ForMember(d => d.UserName,
                    mo => mo.MapFrom(s => s.Email))
                .ForMember(d => d.UserStatus,
                    mo => mo.MapFrom(s => UserStatus.WaitingConfirmationEmail))
                .ReverseMap();

            CreateMap<ChangeMyLocationRequest, UserGeolocation>()
                .ReverseMap();
        }
    }
}