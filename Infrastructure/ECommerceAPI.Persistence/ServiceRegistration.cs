using ECommerceAPI.Application.Repositories.BasketItemRepositories;
using ECommerceAPI.Application.Repositories.BasketRepositories;
using ECommerceAPI.Application.Repositories.CustomerRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.Services.AuthenticationServices;
using ECommerceAPI.Domain.Entities.UserEntities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.BasketItemRepository;
using ECommerceAPI.Persistence.Repositories.BasketRepository;
using ECommerceAPI.Persistence.Repositories.CustomerRepository;
using ECommerceAPI.Persistence.Repositories.FileRepository;
using ECommerceAPI.Persistence.Repositories.InvoiceFileRepository;
using ECommerceAPI.Persistence.Repositories.OrderRepositories;
using ECommerceAPI.Persistence.Repositories.ProductImageFileRepository;
using ECommerceAPI.Persistence.Repositories.ProductRepositories;
using ECommerceAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        // services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

        services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

        services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ECommerceAPIDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        
        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();

        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExternalAuthentication, AuthService>();
        services.AddScoped<IInternalAuthentication, AuthService>();

        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
    }
}