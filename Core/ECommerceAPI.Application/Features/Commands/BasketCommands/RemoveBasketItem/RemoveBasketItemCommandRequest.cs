using MediatR;

namespace ECommerceAPI.Application.Features.Commands.BasketCommands.RemoveBasketItem;

public class RemoveBasketItemCommandRequest : IRequest<RemoveBasketItemCommandResponse>
{
    public Guid BasketItemId { get; set; }
}