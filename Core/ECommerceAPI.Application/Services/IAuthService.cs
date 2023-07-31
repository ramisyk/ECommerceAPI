using ECommerceAPI.Application.Services.AuthenticationServices;

namespace ECommerceAPI.Application.Services;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{
    
}