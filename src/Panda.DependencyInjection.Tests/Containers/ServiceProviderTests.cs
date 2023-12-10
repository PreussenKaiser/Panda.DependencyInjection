using Panda.DependencyInjection.Abstractions;
using Panda.DependencyInjection.Builders;
using Panda.DependencyInjection.Extensions;
using Panda.DependencyInjection.Tests.Utilities;

namespace Panda.DependencyInjection.Tests.Containers;

public sealed class ServiceProviderTests
{
    private readonly IServiceProvider services = new ServiceCollection()
        .AddSingleton<MockService>()
        .BuildServiceProvider();

    [Fact]
    public void GetService_HappyPath()
    {
        // Act
        var service = services.GetService<MockService>();

        // Assert
        Assert.NotNull(service);
        Assert.IsType<MockService>(service);
    }
}
