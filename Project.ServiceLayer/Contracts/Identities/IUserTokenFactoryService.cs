using System.Threading.Tasks;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Services.Helper;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IUserTokenFactoryService
    {
        Task<JwtTokensData> CreateJwtTokensAsync(User user);

        string GetRefreshTokenSerial(string refreshTokenValue);
    }
}
