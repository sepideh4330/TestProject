using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Project.AutoMapper.Profiles;

namespace Project.AutoMapper
{
    public static class BusinessAutoMapperExtensions
    {
        public static void AddBusinessAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(d => d.AddProfile(new UserProfile()));
            services.AddAutoMapper(d => d.AddProfile(new GeneralProfile()));
            services.AddAutoMapper(d => d.AddProfile(new GeographicalDistanceProfile()));
        }
    }

    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<string, string>()
                .ConvertUsing(str => (str ?? "").Trim());
        }
    }
}
