namespace ECommerceAPI.Application.Services;

public interface IQRCodeService
{
    byte[] GenerateQRCode(string text);
} 