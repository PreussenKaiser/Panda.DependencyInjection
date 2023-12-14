namespace Panda.DependencyInjection.Tests.Utilities;

internal interface ICacheService
{
    void Add<T>(T value, string? key = null) where T : notnull;

    T? Get<T>(string key);
}
