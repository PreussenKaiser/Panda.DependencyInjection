
using Panda.DependencyInjection.Entities;
using System.Reflection;

namespace Panda.DependencyInjection.Containers;

public sealed class ServiceProvider : IServiceProvider
{
    private readonly IEnumerable<ServiceDescriptor> serviceDescriptors;

    internal ServiceProvider(IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        this.serviceDescriptors = serviceDescriptors;
    }

    public object? GetService(Type serviceType)
    {
        ServiceDescriptor foundServiceDescriptor = this.serviceDescriptors.FirstOrDefault(s => s.ServiceType == serviceType)
            ?? throw new ArgumentOutOfRangeException(nameof(serviceType));

        Type foundServiceType = foundServiceDescriptor.ServiceType.IsClass
            ? foundServiceDescriptor.ServiceType
            : foundServiceDescriptor.ImplementationType;

        ConstructorInfo constructorInfo = foundServiceType
            .GetConstructors()
            .FirstOrDefault()
                ?? throw new InvalidOperationException("Could not resolve constructor.");

        object?[] parameters = constructorInfo
            .GetParameters()
            .Select(p => this.GetService(p.ParameterType))
            .ToArray();

        object? foundService = Activator.CreateInstance(foundServiceType, parameters);

        return foundService;
    }
}
