using ECommerceAPI.Application.Repositories.MenuRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.MenuRepositories;

public class MenuWriteRepository: WriteRepository<Menu>, IMenuWriteRepository
{
    public MenuWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}