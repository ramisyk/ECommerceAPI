using ECommerceAPI.Application.Dtos;

namespace ECommerceAPI.Application.Services.AuthenticationServices;

public interface IExternalAuthentication
{
    Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
    Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
}