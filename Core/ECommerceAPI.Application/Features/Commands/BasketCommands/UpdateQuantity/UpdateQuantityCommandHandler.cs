﻿using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.BasketCommands.UpdateQuantity;

public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
{
    private readonly IBasketService _basketService;

    public UpdateQuantityCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.UpdateQuantityAsync(new()
        {
            BasketItemId = request.BasketItemId,
            Quantity = request.Quantity
        });

        return new();    }
}