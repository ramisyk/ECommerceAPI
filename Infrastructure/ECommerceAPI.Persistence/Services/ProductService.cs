using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities;
using System.Text.Json;

namespace ECommerceAPI.Persistence.Services;

public class ProductService : IProductService
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IQRCodeService _qrCodeService;

    public ProductService(IProductReadRepository productReadRepository, IQRCodeService qrCodeService, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _qrCodeService = qrCodeService;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<byte[]> QrCodeToProductAsync(Guid productId)
    {
        Product product = await _productReadRepository.GetByIdAsync(productId);
        
        if (product == null)
            throw new Exception("Product not found");
        
        var plainObject = new
        {
            product.Id,
            product.Name,
            product.Price,
            product.Stock,
            product.CreatedDate
        };
        string plainText = JsonSerializer.Serialize(plainObject);

        return _qrCodeService.GenerateQRCode(plainText);    }

    public async Task StockUpdateToProductAsync(Guid productId, int stock)
    {
        Product product = await _productReadRepository.GetByIdAsync(productId);
        if (product == null)
            throw new Exception("Product not found");

        product.Stock = stock;
        await _productWriteRepository.SaveAsync();    
    }
}