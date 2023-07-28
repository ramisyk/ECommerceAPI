﻿using ECommerceAPI.Application.Abstractions.TokenServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));
        services.AddHttpClient();
    }
}