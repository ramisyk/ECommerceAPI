using ECommerceAPI.Application.Repositories.EndpointRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.EndpointRepositories;

public class EndpointWriteRepository: WriteRepository<Endpoint>, IEndpointWriteRepository
{
    public EndpointWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}