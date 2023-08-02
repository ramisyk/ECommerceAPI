using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken;

public class LoginWithRefreshTokenCommandRequest : IRequest<LoginWithRefreshTokenCommandResponse>
{
    public string RefreshToken { get; set; }
}