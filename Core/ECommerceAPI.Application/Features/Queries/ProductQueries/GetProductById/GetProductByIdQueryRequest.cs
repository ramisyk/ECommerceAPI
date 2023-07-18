using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public Guid Id { get; set; }
}