using ECommerceAPI.Application.Dtos;

namespace ECommerceAPI.Application.Services.AuthenticationServices;

public interface IInternalAuthentication
{
    Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    Task<Token> LoginWithRefreshTokenAsync(string refreshToken);
}