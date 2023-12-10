using Panda.DependencyInjection.Abstractions;
using Panda.DependencyInjection.Containers;
using Panda.DependencyInjection.Entities;

namespace Panda.DependencyInjection.Extensions;

public static class ServiceColectionExtensions
{
    public static IServiceCollection AddSingleton<TService>(this IServiceCollection services)
    {
        var serviceDescriptor = new ServiceDescriptor(typeof(TService), null, ServiceLifetime.Singleton);

        services.Add(serviceDescriptor);

        return services;
    }

    public static IServiceProvider BuildServiceProvider(this IServiceCollection services)
    {
        IDictionary<Type, object?> serviceDescriptors = services
            .ToDictionary(
                s => s.ServiceType,
                s => Activator.CreateInstance(s.ServiceType));

        var serviceProvider = new ServiceProvider(serviceDescriptors);

        return serviceProvider;
    }
}
