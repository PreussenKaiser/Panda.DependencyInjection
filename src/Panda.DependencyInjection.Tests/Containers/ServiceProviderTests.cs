using Panda.DependencyInjection.Builders;
using Panda.DependencyInjection.Containers;
using Panda.DependencyInjection.Extensions;
using Panda.DependencyInjection.Tests.Utilities;

namespace Panda.DependencyInjection.Tests.Containers;

public sealed class ServiceProviderTests
{
    [Fact]
    public void GetService_ImplementationInstanceProvided()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton(new GuidService())
            .BuildServiceProvider();

        // Act
        var mockService = serviceProvider.GetService<GuidService>();
        
        // Assert
        Assert.NotNull(mockService);
        Assert.IsType<GuidService>(mockService);
    }

    [Fact]
    public void GetService_ImplementationTypeProvided()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<GuidService>()
            .BuildServiceProvider();

        // Act
        var mockService = serviceProvider.GetService<GuidService>();

        // Assert
        Assert.NotNull(mockService);
        Assert.IsType<GuidService>(mockService);
    }

    [Fact]
    public void GetService_ServiceAndImplementionTypeProvided()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IGuidService, GuidService>()
            .BuildServiceProvider();

        // Act
        var emptyService = serviceProvider.GetService<IGuidService>();

        // Assert
        Assert.IsAssignableFrom<IGuidService>(emptyService);
    }

    [Fact]
    public void GetService_ServiceAndImplementationTypeProvided_NestedServices()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IGuidService, GuidService>()
            .AddSingleton<ICacheService, CacheService>()
            .BuildServiceProvider();

        // Act
        var cacheService = serviceProvider.GetService<ICacheService>();

        // Assert
        Assert.IsAssignableFrom<ICacheService>(cacheService);
    }
}
