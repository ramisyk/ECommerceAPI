using MediatR;

namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetOrderById;

public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
{
    public Guid Id { get; set; }
}