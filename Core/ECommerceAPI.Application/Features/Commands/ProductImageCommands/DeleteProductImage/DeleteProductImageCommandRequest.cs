using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Application.Features.Commands.ProductImageCommands.DeleteProductImage;

public class DeleteProductImageCommandRequest : IRequest<DeleteProductImageCommandResponse>
{
    public Guid Id { get; set; }

    [FromQuery]
    public Guid? ImageId { get; set; }
}