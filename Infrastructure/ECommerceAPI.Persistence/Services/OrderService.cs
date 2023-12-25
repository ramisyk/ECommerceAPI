using ECommerceAPI.Application.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Orders;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;

    private readonly ICompletedOrderWriteRepository _completedOrderWriteRepository;
    private readonly ICompletedOrderReadRepository _completedOrderReadRepository;

    public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository,
        ICompletedOrderWriteRepository completedOrderWriteRepository,
        ICompletedOrderReadRepository completedOrderReadRepository)
    {
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
        _completedOrderWriteRepository = completedOrderWriteRepository;
        _completedOrderReadRepository = completedOrderReadRepository;
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
        /*.Take((page * size)..size);*/


        var data2 = from order in data
            join completedOrder in _completedOrderReadRepository.Table
                on order.Id equals completedOrder.OrderId into co
            from _co in co.DefaultIfEmpty()
            select new
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                OrderCode = order.OrderCode,
                Basket = order.Basket,
                Completed = _co != null ? true : false
            };

        return new()
        {
            TotalOrderCount = await query.CountAsync(),
            Orders = await data2.Select(o => new
            {
                Id = o.Id,
                CreatedDate = o.CreatedDate,
                OrderCode = o.OrderCode,
                TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
                UserName = o.Basket.User.UserName,
                o.Completed
            }).ToListAsync()
        };
    }

    public async Task<VM_Single_Order> GetOrderByIdAsync(Guid id)
    {
        var data = _orderReadRepository.Table
            .Include(o => o.Basket)
            .ThenInclude(b => b.BasketItems)
            .ThenInclude(bi => bi.Product);

        var data2 = await (from order in data
            join completedOrder in _completedOrderReadRepository.Table
                on order.Id equals completedOrder.OrderId into co
            from _co in co.DefaultIfEmpty()
            select new
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                OrderCode = order.OrderCode,
                Basket = order.Basket,
                Completed = _co != null ? true : false,
                Address = order.Address,
                Description = order.Description
            }).FirstOrDefaultAsync(o => o.Id == id);

        return new()
        {
            Id = data2.Id,
            BasketItems = data2.Basket.BasketItems.Select(bi => new
            {
                bi.Product.Name,
                bi.Product.Price,
                bi.Quantity
            }),
            Address = data2.Address,
            CreatedDate = data2.CreatedDate,
            Description = data2.Description,
            OrderCode = data2.OrderCode,
            Completed = data2.Completed
        };
    }

    public async Task<(bool, VM_Completed_Order)> CompleteOrderAsync(Guid id)
    {
        Order? order = await _orderReadRepository.Table
            .Include(o => o.Basket)
            .ThenInclude(b => b.User)
            .FirstOrDefaultAsync(o => o.Id == id);
        if (order != null)
        {
            await _completedOrderWriteRepository.AddAsync(new() { OrderId = id });
            return (await _completedOrderWriteRepository.SaveAsync() > 0,
                new()
                {
                    OrderCode = order.OrderCode,
                    OrderDate = order.CreatedDate,
                    Username = order.Basket.User.UserName,
                    EMail = order.Basket.User.Email
                });
        }

        return (false, null);
    }
}