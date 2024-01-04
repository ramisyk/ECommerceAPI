using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateStockQrCodeToProduct;

public class UpdateStockQrCodeToProductCommandRequest : IRequest<UpdateStockQrCodeToProductCommandResponse>
{
    public Guid ProductId { get; set; }
    public int Stock { get; set; }
}