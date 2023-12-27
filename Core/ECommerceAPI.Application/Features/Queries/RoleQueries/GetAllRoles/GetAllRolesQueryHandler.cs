using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.RoleQueries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetAllRolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
    {
        var (datas, count) = _roleService.GetAllRoles(request.Page, request.Size);
        return new()
        {
            Datas = datas,
            TotalCount = count
        };
    }
}