using Panda.DependencyInjection.Abstractions;
using Panda.DependencyInjection.Containers;
using Panda.DependencyInjection.Entities;
using Panda.DependencyInjection.Utilities;

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
        var serviceDescriptor = new ServiceDescriptor(typeof(TService), null, ServiceLifetime.Singleton);

        services.Add(serviceDescriptor);

        return services;
    }

    public static IServiceProvider BuildServiceProvider(this IServiceCollection services)
    {
        IDictionary<Type, object> builtServices = services
            .ToDictionary(
                s => s.ServiceType,
                s => ActivatorUtilities.CreateInstance(s.ImplementationType));

        var serviceProvider = new ServiceProvider(builtServices);

        return serviceProvider;
    }
}
