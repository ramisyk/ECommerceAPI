using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;
    public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
    {
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
    }

    public async Task CreateOrderAsync(VM_Create_Order createOrder)
    {
        var orderCode = (new Random().NextDouble() * 10000).ToString();
        // after toString order code use "," for decimal seperator so code need to index of "," instead of ".".
        orderCode = orderCode.Substring(orderCode.IndexOf(",") + 1, orderCode.Length - orderCode.IndexOf(",") - 1);

        await _orderWriteRepository.AddAsync(new()
        {
            Address = createOrder.Address,
            Id = createOrder.BasketId,
            Description = createOrder.Description,
            OrderCode = orderCode
        });
        await _orderWriteRepository.SaveAsync();
    }

    public async Task<VM_List_Order> GetAllOrdersAsync(int page, int size)
    {
        var query = _orderReadRepository.Table.Include(o => o.Basket)
            .ThenInclude(b => b.User)
            .Include(o => o.Basket)
            .ThenInclude(b => b.BasketItems)
            .ThenInclude(bi => bi.Product);
        
        var data = query.Skip(page * size).Take(size);
        return new()
        {
            TotalOrderCount = await query.CountAsync(),
            Orders = await data.Select(o => new
            {
                Id = o.Id,
                CreatedDate = o.CreatedDate,
                OrderCode = o.OrderCode,
                TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
                UserName = o.Basket.User.UserName
            }).ToListAsync()
        };

    }

    public async Task<VM_Single_Order> GetOrderByIdAsync(Guid id)
    {
        var data = await _orderReadRepository.Table
            .Include(o => o.Basket)
            .ThenInclude(b => b.BasketItems)
            .ThenInclude(bi => bi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        return new()
        {
            Id = data.Id,
            BasketItems = data.Basket.BasketItems.Select(bi => new
            {
                bi.Product.Name,
                bi.Product.Price,
                bi.Quantity
            }),
            Address = data.Address,
            CreatedDate = data.CreatedDate,
            Description = data.Description,
            OrderCode = data.OrderCode
        };
    }
}