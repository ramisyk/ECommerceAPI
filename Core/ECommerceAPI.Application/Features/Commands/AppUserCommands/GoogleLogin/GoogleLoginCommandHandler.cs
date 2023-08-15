using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.GoogleLogin;

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
{
    private readonly IAuthService _authService;

    public GoogleLoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.GoogleLoginAsync(request.IdToken, 1000);
        return new()
        {
            Token = token
        };
    }
}