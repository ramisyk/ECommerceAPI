using MediatR;

namespace ECommerceAPI.Application.Features.Commands.RoleCommands.DeleteRole;

public class DeleteRoleCommandRequest: IRequest<DeleteRoleCommandResponse>
{
    public string Id { get; set; }
}