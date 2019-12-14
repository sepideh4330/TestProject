using AutoMapper;
using Project.DomainClasses.Entities.Identities;
using Project.Dto.GeographicalDistance.GetGeographicalDistanceList.Helper;

namespace Project.AutoMapper.Profiles
{
    public class GeographicalDistanceProfile : Profile
    {
        public GeographicalDistanceProfile()
        {
            CreateMap<GeographicalDistance, GeographicalDistanceItem>().ReverseMap();
        }
    }
}
