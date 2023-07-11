using ECommerceAPI.Application.Repositories.CustomerRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepository;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepository;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.CustomerRepository;
using ECommerceAPI.Persistence.Repositories.FileRepository;
using ECommerceAPI.Persistence.Repositories.InvoiceFileRepository;
using ECommerceAPI.Persistence.Repositories.OrderRepositories;
using ECommerceAPI.Persistence.Repositories.ProductImageFileRepository;
using ECommerceAPI.Persistence.Repositories.ProductRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();

        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
    }
}