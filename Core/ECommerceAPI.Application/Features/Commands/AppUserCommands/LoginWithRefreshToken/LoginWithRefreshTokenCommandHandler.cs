using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken;

public class LoginWithRefreshTokenCommandHandler : IRequestHandler<LoginWithRefreshTokenCommandRequest, LoginWithRefreshTokenCommandResponse>
{
    readonly IAuthService _authService;

    public LoginWithRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginWithRefreshTokenCommandResponse> Handle(LoginWithRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        Token token = await _authService.LoginWithRefreshTokenAsync(request.RefreshToken);
        return new()
        {
            Token = token
        };
    }
}