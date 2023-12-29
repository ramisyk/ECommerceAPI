using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.UserQueries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUsersAsync(request.Page, request.Size);
        return new()
        {
            Users = users,
            TotalUsersCount = _userService.TotalUsersCount
        };    }
}