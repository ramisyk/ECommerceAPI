using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities;
using System.Text.Json;

namespace ECommerceAPI.Persistence.Services;

public class ProductService : IProductService
{
    readonly IProductReadRepository _productReadRepository;
    readonly IQRCodeService _qrCodeService;

    public ProductService(IProductReadRepository productReadRepository, IQRCodeService qrCodeService)
    {
        _productReadRepository = productReadRepository;
        _qrCodeService = qrCodeService;
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
}