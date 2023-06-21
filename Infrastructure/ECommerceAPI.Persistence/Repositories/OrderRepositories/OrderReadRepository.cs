using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.OrderRepositories;

public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}