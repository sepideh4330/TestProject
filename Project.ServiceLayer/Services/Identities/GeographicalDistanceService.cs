using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Common.Extensions;
using Project.Common.Utilities.DtoHelper;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.Dto.GeographicalDistance.AddGeographicalDistance;
using Project.Dto.GeographicalDistance.GetGeographicalDistanceList;
using Project.Dto.GeographicalDistance.GetGeographicalDistanceList.Helper;
using Project.ServiceLayer.Contracts.Identities;
using Project.ServiceLayer.Messages;

namespace Project.ServiceLayer.Services.Identities
{
    public class GeographicalDistanceService : IGeographicalDistanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<GeographicalDistance> _geographicalDistances;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GeographicalDistanceService(
            IUserService userService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));
            _geographicalDistances = _unitOfWork.Set<GeographicalDistance>();
        }


        public async Task<AddGeographicalDistanceResponse> AddGeographicalDistanceAsync(AddGeographicalDistanceRequest request)
        {
            var response = new AddGeographicalDistanceResponse();
            double rlat1 = Math.PI * double.Parse(request.sLatitude) / 180;
            double rlat2 = Math.PI * double.Parse(request.eLatitude) / 180;
            double theta = double.Parse(request.sLongitude) - double.Parse(request.eLongitude);
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            response.Calculation = (dist * 1.609344).ToString();
            var currentUserId = _userService.GetCurrentUserId();
            var geographicalDistance = new GeographicalDistance();
            geographicalDistance.UserId = currentUserId;
            geographicalDistance.Calculation = double.Parse(response.Calculation);
            _geographicalDistances.Add(geographicalDistance);
            await _unitOfWork.SaveChangesAsync();
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.AddGeographicalDistanceSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }

        public async Task<GetGeographicalDistanceListResponse> GetGeographicalDistanceListAsync()
        {
            var response = new GetGeographicalDistanceListResponse();
            var currentUserId = _userService.GetCurrentUserId();
            var geographicalDistances = await _geographicalDistances.AsNoTracking().Where(d => d.UserId == currentUserId).ToListAsync();
            response.GeographicalDistanceItems = _mapper.Map<List<GeographicalDistanceItem>>(geographicalDistances);
            return response.ReturnWithCode(AuthenticationMessageHelper.Code.GetGeographicalDistanceListSuccess.Value(), AuthenticationMessageHelper.ResponseMessages);
        }
    }
}
