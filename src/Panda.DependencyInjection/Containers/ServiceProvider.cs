
namespace Panda.DependencyInjection.Containers;

public sealed class ServiceProvider : IServiceProvider
{
    private readonly IDictionary<Type, object?> serviceDescriptors;

    internal ServiceProvider(IDictionary<Type, object?> serviceDescriptors)
    {
        this.serviceDescriptors = serviceDescriptors;
    }

    public object? GetService(Type serviceType)
    {
        if (serviceDescriptors.TryGetValue(serviceType, out object? value))
        {
            return value;
        }

        throw new ArgumentOutOfRangeException(nameof(serviceType), "Specified service does not exist.");
    }
}
