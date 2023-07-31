using ECommerceAPI.Application.Dtos.UserDtos;

namespace ECommerceAPI.Application.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateAsync(CreateUser user);
}