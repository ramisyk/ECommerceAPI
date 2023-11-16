using ECommerceAPI.Application.ViewModels.Orders;

namespace ECommerceAPI.Application.Services;

public interface IOrderService
{
    Task CreateOrderAsync(VM_Create_Order createOrder);
}