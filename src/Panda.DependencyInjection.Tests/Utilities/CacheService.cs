namespace Panda.DependencyInjection.Tests.Utilities;

internal class CacheService(IGuidService guidService) : ICacheService
{
    private readonly IGuidService guidService = guidService;
    private readonly Dictionary<string, object> cache = [];

    public void Add<T>(T value, string? key = null) where T : notnull
    {
        key ??= this.guidService.NewGuid().ToString();

        this.cache.Add(key, value);
    }

    public T? Get<T>(string key)
    {
        if (this.cache.TryGetValue(key, out object? result))
        {
            return (T)result;
        }

        return default;
    }
}
