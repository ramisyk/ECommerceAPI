using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.UserQueries.GetRolesToUser;

public class GetRolesToUserQueryHandler : IRequestHandler<GetRolesToUserQueryRequest, GetRolesToUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetRolesToUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetRolesToUserQueryResponse> Handle(GetRolesToUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userRoles = await _userService.GetRolesToUserAsync(request.UserId);
        return new()
        {
            UserRoles = userRoles
        };
    }
}