using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.VerifyResetToken;

public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommandRequest, VerifyResetTokenCommandResponse>
{
    readonly IAuthService _authService;

    public VerifyResetTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<VerifyResetTokenCommandResponse> Handle(VerifyResetTokenCommandRequest request, CancellationToken cancellationToken)
    {
        bool state = await _authService.VerifyResetTokenAsync(request.ResetToken, request.UserId);
        return new()
        {
            State = state
        };
    }
}