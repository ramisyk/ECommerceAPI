using MediatR;

namespace ECommerceAPI.Application.Features.Commands.RoleCommands.CreateRole;

public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; }
}