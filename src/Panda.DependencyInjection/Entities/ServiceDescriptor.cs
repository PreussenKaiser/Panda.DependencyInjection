namespace Panda.DependencyInjection.Entities;

public sealed class ServiceDescriptor(Type serviceType, Type? implementationType = null, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
{
    /// <summary>
    /// Underlying implementation or contract type.
    /// </summary>
    public readonly Type ServiceType = serviceType;

    public readonly Type ImplementationType = implementationType ?? serviceType;

    public readonly ServiceLifetime ServiceLifetime = serviceLifetime;
}
