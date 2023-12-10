using Panda.DependencyInjection.Abstractions;
using System.Runtime.CompilerServices;

namespace Panda.DependencyInjection.Extensions;

public static class ServiceProviderExtensions
{
    public static TService? GetService<TService>(this IServiceProvider serviceProvider) where TService : class
    {
        TService? service = serviceProvider.GetService(typeof(TService)) as TService;

        return service;
    }

    public static IServiceScope CreateScope(this IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }
}
