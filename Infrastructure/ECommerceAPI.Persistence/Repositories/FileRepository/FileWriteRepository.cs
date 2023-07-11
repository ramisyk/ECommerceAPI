using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Domain.Entities.FileEntities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.FileRepository;

public class FileWriteRepository : WriteRepository<BaseFile>, IFileWriteRepository
{
    public FileWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}