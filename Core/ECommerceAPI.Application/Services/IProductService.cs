namespace ECommerceAPI.Application.Services;

public interface IProductService
{
    Task<byte[]> QrCodeToProductAsync(Guid productId);
    Task StockUpdateToProductAsync(Guid productId, int stock);
}