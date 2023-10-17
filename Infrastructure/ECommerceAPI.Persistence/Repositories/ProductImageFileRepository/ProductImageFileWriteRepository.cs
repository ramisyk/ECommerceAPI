using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Domain.Entities.FileEntities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.ProductImageFileRepository;

public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
{
    public ProductImageFileWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}