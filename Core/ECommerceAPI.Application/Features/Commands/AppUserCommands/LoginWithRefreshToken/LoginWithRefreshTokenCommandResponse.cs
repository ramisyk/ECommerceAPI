using ECommerceAPI.Application.Dtos;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken;

public class LoginWithRefreshTokenCommandResponse
{
    public Token Token { get; set; }
}