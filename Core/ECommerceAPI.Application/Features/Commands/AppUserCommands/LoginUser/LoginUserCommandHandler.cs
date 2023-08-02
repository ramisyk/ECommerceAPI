using ECommerceAPI.Application.Abstractions.TokenServices;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 15);
        return new LoginUserSuccessCommandResponse()
        {
            Token = token
        };
    }
}