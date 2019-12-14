using System.Collections.Generic;
using System.Security.Claims;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IAntiForgeryCookieService
    {
        void RegenerateAntiForgeryCookies(IEnumerable<Claim> claims);
        void DeleteAntiForgeryCookies();
    }
}
