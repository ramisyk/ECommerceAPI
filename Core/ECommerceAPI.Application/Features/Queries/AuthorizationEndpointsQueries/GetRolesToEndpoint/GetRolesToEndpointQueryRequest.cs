using MediatR;

namespace ECommerceAPI.Application.Features.Queries.AuthorizationEndpointsQueries.GetRolesToEndpoint;

public class GetRolesToEndpointQueryRequest : IRequest<GetRolesToEndpointQueryResponse>
{
    public string Code { get; set; }
    public string Menu { get; set; }
}