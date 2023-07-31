using Azure.Core;
using ECommerceAPI.Application.Dtos.UserDtos;
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

    //public async Task<CreateUserResponse> CreateAsync(CreateUser user)
    //{
    //    IdentityResult result = await _userManager.CreateAsync(new()
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        UserName = user.Username,
    //        Email = user.Email,
    //        NameSurname = user.NameSurname,
    //    }, user.Password);

    //    CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

    //    if (result.Succeeded)
    //        response.Message = "User Created";
    //    else
    //        foreach (var error in result.Errors)
    //            response.Message += $"{error.Code} - {error.Description}\n";

    //    return response;
    //}

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
}