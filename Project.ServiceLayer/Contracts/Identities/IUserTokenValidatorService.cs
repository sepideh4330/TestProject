using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IUserTokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }
}
