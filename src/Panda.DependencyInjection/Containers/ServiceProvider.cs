
namespace Panda.DependencyInjection.Containers;

public sealed class ServiceProvider : IServiceProvider
{
    private readonly IDictionary<Type, object> builtServices;

    internal ServiceProvider(IDictionary<Type, object> builtServices)
    {
        this.builtServices = builtServices;
    }

    public object? GetService(Type serviceType)
    {
        if (this.builtServices.TryGetValue(serviceType, out object? serviceInstance))
        {
            return serviceInstance;
        }

        throw new ArgumentOutOfRangeException(nameof(serviceType), "Could not find service.");
    }
}
