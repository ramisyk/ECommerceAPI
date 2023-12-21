using ECommerceAPI.Application.Dtos.UserDtos;
using ECommerceAPI.Domain.Entities.UserEntities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceAPI.Application.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateAsync(CreateUser user);
    Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
}