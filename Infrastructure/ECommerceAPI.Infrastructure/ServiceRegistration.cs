using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Abstractions.TokenServices;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.Services.Configurations;
using ECommerceAPI.Infrastructure.Enums;
using ECommerceAPI.Infrastructure.Services;
using ECommerceAPI.Infrastructure.Services.Configurations;
using ECommerceAPI.Infrastructure.Services.Storage;
using ECommerceAPI.Infrastructure.Services.Storage.LocalStorage;
using ECommerceAPI.Infrastructure.Services.TokenServices;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageService, StorageService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped<IMailService, MailService>();
        serviceCollection.AddScoped<IApplicationService, ApplicationServices>();

    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
}