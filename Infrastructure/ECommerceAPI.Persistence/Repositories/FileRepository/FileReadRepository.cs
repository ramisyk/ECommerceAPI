using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Domain.Entities.FileEntities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.FileRepository;

public class FileReadRepository : ReadRepository<BaseFile>, IFileReadRepository
{
    public FileReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}