using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductImageQueries.GetProductImages;

public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
{
    public string Id { get; set; }
}