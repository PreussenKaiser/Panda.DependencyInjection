namespace Panda.DependencyInjection.Extensions;

public static class ServiceProviderExtensions
{
    public static T? GetService<T>(this IServiceProvider serviceProvider) where T : class
    {
        var service = serviceProvider.GetService(typeof(T)) as T;

        return service;
    }
}
