using ECommerceAPI.Application.Dtos.UserDtos;
using ECommerceAPI.Domain.Entities.UserEntities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceAPI.Application.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateAsync(CreateUser user);
    Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenExpirationDate, int refreshTokenLifeTime);
}