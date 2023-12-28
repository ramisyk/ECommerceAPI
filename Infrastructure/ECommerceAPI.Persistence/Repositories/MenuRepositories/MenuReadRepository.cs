using ECommerceAPI.Application.Repositories.MenuRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.MenuRepositories;

public class MenuReadRepository: ReadRepository<Menu>, IMenuReadRepository
{
    public MenuReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}