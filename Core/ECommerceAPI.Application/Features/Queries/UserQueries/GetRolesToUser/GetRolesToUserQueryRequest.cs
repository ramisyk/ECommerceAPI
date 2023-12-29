using MediatR;

namespace ECommerceAPI.Application.Features.Queries.UserQueries.GetRolesToUser;

public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
{
    public string UserId { get; set; }
}