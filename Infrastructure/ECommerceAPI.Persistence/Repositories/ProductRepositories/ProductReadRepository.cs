using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.ProductRepositories;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}