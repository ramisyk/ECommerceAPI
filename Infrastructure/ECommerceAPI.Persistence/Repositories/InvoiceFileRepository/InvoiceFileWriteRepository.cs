using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Domain.Entities.FileEntities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;

namespace ECommerceAPI.Persistence.Repositories.InvoiceFileRepository;

public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
{
    public InvoiceFileWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}