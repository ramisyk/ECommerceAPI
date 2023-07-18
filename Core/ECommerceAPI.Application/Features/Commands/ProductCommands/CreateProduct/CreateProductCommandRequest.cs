﻿using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}