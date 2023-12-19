using ECommerceAPI.Application.ViewModels.Orders;
using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Services;

public interface IOrderService
{
    Task CreateOrderAsync(VM_Create_Order createOrder);
    Task<VM_List_Order> GetAllOrdersAsync(int page, int size);
    Task<VM_Single_Order> GetOrderByIdAsync(Guid id);

}