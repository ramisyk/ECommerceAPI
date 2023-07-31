using ECommerceAPI.Application.Dtos.UserDtos;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponse response = await _userService.CreateAsync(new()
        {
            Email = request.Email,
            NameSurname = request.NameSurname,
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
            Username = request.Username,
        });

        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded,
        };
    }
}