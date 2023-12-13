using Panda.DependencyInjection.Abstractions;
using Panda.DependencyInjection.Entities;
using System.Collections;

namespace Panda.DependencyInjection.Builders;

public sealed class ServiceCollection : IServiceCollection
{
    private readonly List<ServiceDescriptor> serviceDescriptors = [];
    private bool isReadOnly;

    public ServiceDescriptor this[int index]
    {
        get => this.serviceDescriptors[index];
        set => this.serviceDescriptors[index] = value;
    }

    public int Count => this.serviceDescriptors.Count;

    public bool IsReadOnly => this.isReadOnly;

    public void Add(ServiceDescriptor item)
    {
        this.CheckReadOnly();

        this.serviceDescriptors.Add(item);
    }

    public void Clear()
    {
        this.CheckReadOnly();

        this.serviceDescriptors.Clear();
    }

    public bool Contains(ServiceDescriptor item)
    {
        bool result = this.serviceDescriptors.Contains(item);

        return result;
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        this.serviceDescriptors.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        IEnumerator<ServiceDescriptor> enumerator = this.serviceDescriptors.GetEnumerator();

        return enumerator;
    }

    public int IndexOf(ServiceDescriptor item)
    {
        int result = this.serviceDescriptors.IndexOf(item);

        return result;
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        this.CheckReadOnly();

        this.serviceDescriptors.Insert(index, item);
    }

    public bool Remove(ServiceDescriptor item)
    {
        this.CheckReadOnly();

        bool result = this.serviceDescriptors.Remove(item);

        return result;
    }

    public void RemoveAt(int index)
    {
        this.CheckReadOnly();

        this.serviceDescriptors.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        IEnumerator enumerator = this.serviceDescriptors.GetEnumerator();

        return enumerator;
    }

    public void MakeReadOnly()
    {
        this.isReadOnly = true;
    }

    /// <summary>
    /// Throws an exception in <see cref="IsReadOnly"/> is <see langword="true"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    private void CheckReadOnly()
    {
        if (this.isReadOnly)
        {
            throw new InvalidOperationException($"{nameof(ServiceCollection)} is readonly");
        }
    }
}
