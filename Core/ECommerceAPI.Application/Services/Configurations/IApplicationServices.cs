using ECommerceAPI.Application.Dtos.Configurations;

namespace ECommerceAPI.Application.Services.Configurations;

public interface IApplicationServices
{
    List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
}