﻿using ECommerceAPI.Application.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.BasketCommands.AddItemToBasket;
using ECommerceAPI.Application.Features.Commands.BasketCommands.RemoveBasketItem;
using ECommerceAPI.Application.Features.Commands.BasketCommands.UpdateQuantity;
using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;
using MediatR;
using ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageCommands.ChangeShowcaseImage;
using ECommerceAPI.Application.Features.Commands.ProductImageCommands.DeleteProductImage;
using ECommerceAPI.Application.Features.Commands.ProductImageCommands.UploadProductImages;
using ECommerceAPI.Application.Features.Queries.BasketQueries.GetBasketItems;
using ECommerceAPI.Application.Features.Queries.ProductImageQueries.GetProductImages;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketItems(
            [FromQuery] GetBasketItemsQueryRequest getBasketItemsQueryRequest)
        {
            List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem(
            [FromRoute] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
            return Ok(response);

        }
    }
}