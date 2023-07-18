using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public object Products { get; set; }
    public int TotalCount { get; set; }
}