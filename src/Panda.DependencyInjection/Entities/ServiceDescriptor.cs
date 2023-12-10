namespace Panda.DependencyInjection.Entities;

/// <summary>
/// Describes a service with by it's implementation and lifetime.
/// </summary>
public sealed class ServiceDescriptor(Type serviceType, Type? implementationType, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
{
    public readonly Type ServiceType = serviceType;
    public readonly Type? ImplementationType = implementationType;
    public readonly ServiceLifetime ServiceLifetime = serviceLifetime;
}
