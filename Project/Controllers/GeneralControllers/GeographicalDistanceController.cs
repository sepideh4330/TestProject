using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.Common.Controllers;
using Project.Common.Extensions;
using Project.Common.Helpers;
using Project.Dto.GeographicalDistance.AddGeographicalDistance;
using Project.Dto.GeographicalDistance.GetGeographicalDistanceList;
using Project.Dto.User.ChangeMyUserPassword;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.Controllers.GeneralControllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class GeographicalDistanceController : BaseApiController
    {
        private readonly IGeographicalDistanceService _geographicalDistanceService;

        public GeographicalDistanceController(IGeographicalDistanceService geographicalDistanceService)
        {
            _geographicalDistanceService = geographicalDistanceService;
            _geographicalDistanceService.CheckArgumentIsNull(nameof(_geographicalDistanceService));
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        [ActionName("AddGeographicalDistance")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(AddGeographicalDistanceResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGeographicalDistance([FromBody]AddGeographicalDistanceRequest request)
        {
            return await ExecuteServiceAsync(() => _geographicalDistanceService.AddGeographicalDistanceAsync(request));
        }

        [IgnoreAntiforgeryToken]
        [HttpGet("[action]")]
        [ActionName("GetGeographicalDistanceList")]
        [ProducesResponseType(ProducesResponseTypeCode._200, Type = typeof(GetGeographicalDistanceListResponse))]
        [ProducesResponseType(ProducesResponseTypeCode._500, Type = typeof(ModelStateDictionary))]
        [ProducesResponseType(ProducesResponseTypeCode._400, Type = typeof(Exception))]
        [Authorize]
        public async Task<IActionResult> GetGeographicalDistanceList()
        {
            return await ExecuteServiceAsync(() => _geographicalDistanceService.GetGeographicalDistanceListAsync());
        }
    }
}