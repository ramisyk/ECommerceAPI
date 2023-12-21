using ECommerceAPI.Application.Services.AuthenticationServices;

namespace ECommerceAPI.Application.Services;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{
    Task PasswordResetAsnyc(string email);
    Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
}