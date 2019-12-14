using System.Collections.Generic;
using Project.Common.Utilities.DtoHelper;
using Project.Dto.GeographicalDistance.GetGeographicalDistanceList.Helper;

namespace Project.Dto.GeographicalDistance.GetGeographicalDistanceList
{
    public class GetGeographicalDistanceListResponse : DtoResponse
    {
        public GetGeographicalDistanceListResponse()
        {
            GeographicalDistanceItems = new List<GeographicalDistanceItem>();
        }

        public List<GeographicalDistanceItem> GeographicalDistanceItems { get; set; }
    }
}
