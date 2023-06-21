using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.ProductRepositories;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}