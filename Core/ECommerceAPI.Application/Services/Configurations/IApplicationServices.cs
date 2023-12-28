using ECommerceAPI.Application.Dtos.Configurations;

namespace ECommerceAPI.Application.Services.Configurations;

public interface IApplicationService
{
    List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
}