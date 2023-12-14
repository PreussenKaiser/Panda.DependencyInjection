
namespace Panda.DependencyInjection.Tests.Utilities;

internal class GuidService : IGuidService
{
    private readonly Guid guid = Guid.NewGuid();

    public Guid NewGuid()
    {
        return this.guid;
    }
}
