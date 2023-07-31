using ECommerceAPI.Application.Abstractions.TokenServices;
using ECommerceAPI.Application.Dtos.Facebook;
using ECommerceAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Services;


namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.FacebookLogin;

public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
{
    private readonly IAuthService _authService;

    public FacebookLoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.FacebookLoginAsync(request.AuthToken, 1000);
        return new FacebookLoginCommandResponse()
        {
            Token = token
        };
    }
}