using ECommerceAPI.Application.Const;
using ECommerceAPI.Application.CustomAttribute;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.CreateUser;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.FacebookLogin;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.GoogleLogin;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;
using ECommerceAPI.Application.Features.Commands.AppUserCommands.UpdatePassword;
using ECommerceAPI.Application.Features.Commands.UserCommands.AssignRoleToUser;
using ECommerceAPI.Application.Features.Queries.UserQueries.GetAllUsers;
using ECommerceAPI.Application.Features.Queries.UserQueries.GetRolesToUser;
using ECommerceAPI.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IMailService _mailService;

        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }
        
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = AuthorizeDefinitionConstants.Users)]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(response);
        }
        
        [HttpGet("get-roles-to-user/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = AuthorizeDefinitionConstants.Users)]
        public async Task<IActionResult> GetRolesToUser([FromRoute]GetRolesToUserQueryRequest getRolesToUserQueryRequest)
        {
            GetRolesToUserQueryResponse response = await _mediator.Send(getRolesToUserQueryRequest);
            return Ok(response);
        }

        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Assign Role To User", Menu = AuthorizeDefinitionConstants.Users)]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        {
            AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }
        
    }
}
