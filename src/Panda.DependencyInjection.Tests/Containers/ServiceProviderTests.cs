using Panda.DependencyInjection.Builders;
using Panda.DependencyInjection.Extensions;
using Panda.DependencyInjection.Tests.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Panda.DependencyInjection.Tests.Containers;

public sealed class ServiceProviderTests
{
    [Fact]
    public void GetService_ImplementationInstanceProvided()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton(new EmptyService())
            .BuildServiceProvider();

        // Act
        var mockService = serviceProvider.GetService<EmptyService>();
        
        // Assert
        Assert.NotNull(mockService);
        Assert.IsType<EmptyService>(mockService);
    }

    [Fact]
    public void GetService_ImplementationTypeProvided()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<EmptyService>()
            .BuildServiceProvider();

        // Act
        var mockService = serviceProvider.GetService<EmptyService>();

        // Assert
        Assert.NotNull(mockService);
        Assert.IsType<EmptyService>(mockService);
    }

    [Fact]
    public void GetService_ServiceAndImplementionTypeProvided()
    {
        // Arrange
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IEmptyService, EmptyService>()
            .BuildServiceProvider();

        // Act
        var emptyService = serviceProvider.GetService<IEmptyService>();

        // Assert
        Assert.IsAssignableFrom<IEmptyService>(emptyService);
    }
}
