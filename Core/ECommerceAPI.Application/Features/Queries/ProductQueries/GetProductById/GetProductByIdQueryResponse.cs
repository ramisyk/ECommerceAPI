using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;

public class GetProductByIdQueryResponse
{
    public Product? Product { get; set; }
}