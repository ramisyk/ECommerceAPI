using ECommerceAPI.Application.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.CompletedOrderRepositories;

public class CompletedOrderReadRepository : ReadRepository<CompletedOrder>, ICompletedOrderReadRepository{
    public CompletedOrderReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}