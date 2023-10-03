using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System.Net;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductHubService _productHubService;

    public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductHubService productHubService)
    {
        _productWriteRepository = productWriteRepository;
        _productHubService = productHubService;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        /*
        await _productWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        });

        */

        var productList = new List<Product>();
        for (int i = 27; i < 101; i++)
        {
            var product = new Product()
            {
                Name = $"Ürün {i}",
                Stock = i * 10,
                Price = i * 100
            };
            productList.Add(product);
        }

        await _productWriteRepository.AddRangeAsync(productList);

        await _productWriteRepository.SaveAsync();

        await _productHubService.ProductAddedMessageAsync($"{request.Name} created...");
        return new();
    }
}