using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.AssignRoleToUser;

public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommandRequest, AssignRoleToUserCommandResponse>
{
    private readonly IUserService _userService;

    public AssignRoleToUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AssignRoleToUserCommandResponse> Handle(AssignRoleToUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userService.AssignRoleToUserAsnyc(request.UserId, request.Roles);
        return new();    }
}