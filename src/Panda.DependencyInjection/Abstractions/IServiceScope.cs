namespace Panda.DependencyInjection.Abstractions;

public interface IServiceScope : IDisposable
{
    IServiceProvider ServiceProvider { get; }
}
