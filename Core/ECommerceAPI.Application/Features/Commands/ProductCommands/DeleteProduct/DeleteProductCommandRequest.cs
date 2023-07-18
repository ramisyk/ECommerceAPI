using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public Guid Id { get; set; }
}