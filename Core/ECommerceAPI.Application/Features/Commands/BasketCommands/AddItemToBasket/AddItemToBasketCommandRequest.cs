using MediatR;

namespace ECommerceAPI.Application.Features.Commands.BasketCommands.AddItemToBasket;

public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}