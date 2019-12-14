using System.Threading.Tasks;
using Project.Dto.GeographicalDistance.AddGeographicalDistance;
using Project.Dto.GeographicalDistance.GetGeographicalDistanceList;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IGeographicalDistanceService
    {
        Task<AddGeographicalDistanceResponse> AddGeographicalDistanceAsync(AddGeographicalDistanceRequest request);

        Task<GetGeographicalDistanceListResponse> GetGeographicalDistanceListAsync();
    }
}
