using System;
using System.Threading.Tasks;
using Project.DomainClasses.Entities.Identities;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IUserTokenStorageService
    {
        Task AddUserTokenStorageAsync(UserTokenStorage userTokenStorage);
        Task AddUserTokenStorageAsync(User user, string refreshTokenSerial, string accessToken, string refreshTokenSourceSerial);
        Task<bool> IsValidTokenAsync(string accessToken, Guid userId);
        Task DeleteExpiredTokensAsync();
        Task<UserTokenStorage> FindTokenAsync(string refreshToken);
        Task DeleteTokenAsync(string refreshToken);
        Task DeleteUserTokenAsync(Guid userId);
        Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource);
        Task InvalidateUserTokenStoragesAsync(Guid userId);
        Task RevokeUserBearerTokensAsync(string userIdValue, string refreshToken);
    }
}
