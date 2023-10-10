using ECommerceAPI.Application.Repositories.BasketItemRepository;
using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.BasketItemRepository;

public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
{
    public BasketItemWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}