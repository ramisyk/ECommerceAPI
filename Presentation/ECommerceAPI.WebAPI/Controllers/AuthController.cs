using ECommerceAPI.Application.Features.Commands.AppUserCommands.FacebookLogin;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.GoogleLogin;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.PasswordReset;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginWithRefreshToken([FromBody] LoginWithRefreshTokenCommandRequest loginWithRefreshTokenCommandRequest)
        {
            LoginWithRefreshTokenCommandResponse response = await _mediator.Send(loginWithRefreshTokenCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FacebookLogin(FacebookLoginCommandRequest facebookLoginCommandRequest)
        {
            FacebookLoginCommandResponse response = await _mediator.Send(facebookLoginCommandRequest);
            return Ok(response);
        }
        
        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }

        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
            return Ok(response);
        }
    }
}
