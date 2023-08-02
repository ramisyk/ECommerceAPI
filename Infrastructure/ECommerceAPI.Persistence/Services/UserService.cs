using Azure.Core;
using ECommerceAPI.Application.Dtos.UserDtos;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.CreateUser;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<CreateUserResponse> CreateAsync(CreateUser model)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = model.Username,
            Email = model.Email,
            NameSurname = model.NameSurname,
        }, model.Password);

        CreateUserResponse response = new() { Succeeded = result.Succeeded };

        if (result.Succeeded)
            response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
        else
            foreach (var error in result.Errors)
                response.Message += $"{error.Code} - {error.Description}\n";

        return response;
    }

    public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenExpirationDate, int refreshTokenLifeTime)
    {
        user.RefreshToken = refreshToken;
        user.RefreshTokenEndDate = accessTokenExpirationDate.AddSeconds(refreshTokenLifeTime);
        await _userManager.UpdateAsync(user);
    }
}