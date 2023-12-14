using Panda.DependencyInjection.Abstractions;
using Panda.DependencyInjection.Containers;
using Panda.DependencyInjection.Entities;

namespace Panda.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSingleton<TImplementation>(
        this IServiceCollection services,
        TImplementation serviceImplementation)
            where TImplementation : class
    {
        var serviceDescriptor = new ServiceDescriptor(serviceImplementation.GetType(), serviceImplementation.GetType());

        services.Add(serviceDescriptor);

        return services;
    }

    public static IServiceCollection AddSingleton<TImplementation>(this IServiceCollection services)
    {
        var implementationType = typeof(TImplementation);
        var serviceDescriptor = new ServiceDescriptor(implementationType, implementationType, ServiceLifetime.Singleton);

        services.Add(serviceDescriptor);

        return services;
    }

    public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services)
        where TImplementation : TService
    {
        var serviceDescriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton);

        services.Add(serviceDescriptor);

        return services;
    }

    public static IServiceProvider BuildServiceProvider(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        var serviceProvider = new ServiceProvider(services);

        return serviceProvider;
    }
}
