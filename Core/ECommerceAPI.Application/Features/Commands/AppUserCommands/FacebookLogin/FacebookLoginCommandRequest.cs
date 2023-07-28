using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.FacebookLogin;

public class FacebookLoginCommandRequest : IRequest<FacebookLoginCommandResponse>
{
    public string AuthToken { get; set; }
}