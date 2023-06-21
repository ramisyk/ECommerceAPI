using ECommerceAPI.Application.Repositories.CustomerRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.CustomerRepository;

public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}