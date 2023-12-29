using ECommerceAPI.Application.Dtos.UserDtos;
using ECommerceAPI.Domain.Entities.UserEntities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceAPI.Application.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateAsync(CreateUser user);
    Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    Task<List<ListUser>> GetAllUsersAsync(int page, int size);
    int TotalUsersCount { get; }
    Task AssignRoleToUserAsnyc(string userId, string[] roles);
    Task<string[]> GetRolesToUserAsync(string userIdOrName);
    Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
}