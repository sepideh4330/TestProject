using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Project.Common.AppSettings;
using Project.Common.Controllers;
using Project.Common.Extensions;

namespace Project.Controllers.GeneralControllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ApiSettingController : BaseApiController
    {
        private readonly IOptionsSnapshot<SiteSettings> _optionsSnapshotSiteSettings;

        public ApiSettingController(IOptionsSnapshot<SiteSettings> optionsSnapshotSiteSettings)
        {
            _optionsSnapshotSiteSettings = optionsSnapshotSiteSettings;
            _optionsSnapshotSiteSettings.CheckArgumentIsNull(nameof(_optionsSnapshotSiteSettings));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return GetSimpleData(_optionsSnapshotSiteSettings.Value.ApiSettings);
        }
    }
}