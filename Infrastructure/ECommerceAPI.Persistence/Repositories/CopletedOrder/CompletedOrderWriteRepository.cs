using ECommerceAPI.Application.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.CopletedOrder;

public class CompletedOrderWriteRepository : WriteRepository<CompletedOrder>, ICompletedOrderWriteRepository
{
    public CompletedOrderWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}