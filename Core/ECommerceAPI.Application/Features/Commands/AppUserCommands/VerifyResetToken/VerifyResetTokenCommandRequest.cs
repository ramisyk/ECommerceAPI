using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.VerifyResetToken;

public class VerifyResetTokenCommandRequest : IRequest<VerifyResetTokenCommandResponse>
{
    public string ResetToken { get; set; }
    public string UserId { get; set; }
}