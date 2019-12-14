using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Project.DomainClasses.Entities.Identities;
using Project.Dto.User.ChangeMyUserPassword;
using Project.Dto.User.ForgotPassword;
using Project.Dto.User.GetMyProfile;
using Project.Dto.User.Login;
using Project.Dto.User.RefreshToken;
using Project.Dto.User.Register;
using Project.Dto.User.ResetPassword;
using Project.Dto.User.VerificationPhoneNumber;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IUserService : IDisposable
    {
        Guid GetCurrentUserId();

        Task<User> FindByIdAsync(Guid userId);

        Task UpdateLastActivityDateTimeAsync(Guid userId);

        Task UpdateLastLoginDateTimeAsync(Guid userId);

        Task UpdateLastVisitDateTimeAsync(ClaimsPrincipal claimsPrincipal);

        Task<LoginResponse> LoginAsync(LoginRequest request);

        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);

        Task<bool> LogoutAsync(string refreshToken);

        Task<VerificationEmailResponse> VerificationEmailAsync(VerificationEmailRequest request);

        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request);

        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);

        Task<ChangeMyUserPasswordResponse> ChangeMyUserPasswordAsync(ChangeMyUserPasswordRequest request);

        Task<GetMyProfileResponse> GetMyProfileAsync();

        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    }
}
