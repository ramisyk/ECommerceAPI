using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Orders;

namespace ECommerceAPI.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public OrderService(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task CreateOrderAsync(VM_Create_Order createOrder)
    {
        await _orderWriteRepository.AddAsync(new()
        {
            Address = createOrder.Address,
            Id = createOrder.BasketId,
            Description = createOrder.Description
        });
        await _orderWriteRepository.SaveAsync();
    }
}