using System.ComponentModel.Design;
using System.Reflection;

namespace Panda.DependencyInjection.Utilities;

public static class ActivatorUtilities
{
    /// <exception cref="InvalidCastException"/>
    public static object CreateInstance(Type type)
    {
        ConstructorInfo? constructorInfo = type
            .GetConstructors()
            .FirstOrDefault()
                ?? throw new InvalidOperationException("No public contructor.");

        ParameterInfo[] parameters = constructorInfo.GetParameters();

        if (parameters.Length == 0)
        {
            return Activator.CreateInstance(type)
                ?? throw new InvalidOperationException("Could not instantiate service.");
        }

        throw new InvalidCastException();
    }
}
