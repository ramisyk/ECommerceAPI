// using Azure.Core;

using ECommerceAPI.Application.Dtos.UserDtos;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.CreateUser;
using ECommerceAPI.Application.Helpers;
using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IProductWriteRepository _repository;

    public UserService(UserManager<AppUser> userManager, IProductWriteRepository repository)
    {
        _userManager = userManager;
        _repository = repository;
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

    public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate,
        int addOnAccessTokenDate)
    {
        user.RefreshToken = refreshToken;
        user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
        await _userManager.UpdateAsync(user);
    }

    public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            resetToken = resetToken.UrlDecode();
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                await _repository.SaveAsync();
            }
            else
                throw new PasswordChangeFailedException();
        }
    }

    public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
    {
        var users = await _userManager.Users
            .Skip(page * size)
            .Take(size)
            .ToListAsync();

        return users.Select(user => new ListUser
        {
            Id = user.Id,
            Email = user.Email,
            NameSurname = user.NameSurname,
            TwoFactorEnabled = user.TwoFactorEnabled,
            UserName = user.UserName
        }).ToList();
    }

    public int TotalUsersCount => _userManager.Users.Count();

    public async Task AssignRoleToUserAsnyc(string userId, string[] roles)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRolesAsync(user, roles);
            await _repository.SaveAsync();

        }
    }

    public async Task<string[]> GetRolesToUserAsync(string userId)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToArray();
        }
        return new string[] { };
    }
}