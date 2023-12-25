using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.PasswordReset;

public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
{
    public string Email { get; set; }
}