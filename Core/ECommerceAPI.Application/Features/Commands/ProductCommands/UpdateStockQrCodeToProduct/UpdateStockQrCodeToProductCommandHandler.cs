using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateStockQrCodeToProduct;

public class UpdateStockQrCodeToProductCommandHandler : IRequestHandler<UpdateStockQrCodeToProductCommandRequest, UpdateStockQrCodeToProductCommandResponse>
{
    private readonly IProductService _productService;

    public UpdateStockQrCodeToProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<UpdateStockQrCodeToProductCommandResponse> Handle(UpdateStockQrCodeToProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productService.StockUpdateToProductAsync(request.ProductId, request.Stock);
        return new();    }
}