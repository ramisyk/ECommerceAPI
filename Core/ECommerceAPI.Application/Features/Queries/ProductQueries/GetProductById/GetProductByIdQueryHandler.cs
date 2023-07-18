using ECommerceAPI.Application.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await _productReadRepository.GetByIdAsync(request.Id, false);
        return new()
        {
            Product = product
        };
    }
}