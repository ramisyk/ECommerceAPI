using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}