namespace ECommerceAPI.Application.Services;

public interface IProductService
{
    Task<byte[]> QrCodeToProductAsync(Guid productId);
}