using Panda.DependencyInjection.Abstractions;
using Panda.DependencyInjection.Entities;
using System.Collections;

namespace Panda.DependencyInjection.Builders;

public sealed class ServiceCollection : IServiceCollection
{
    private readonly List<ServiceDescriptor> descriptors = [];
    private bool isReadOnly;

    public ServiceDescriptor this[int index]
    {
        get => this.descriptors[index];
        set
        {
            this.CheckReadOnly();

            this.descriptors[index] = value;
        }
    }

    public int Count => this.descriptors.Count;

    public bool IsReadOnly => this.isReadOnly;

    public void Add(ServiceDescriptor item)
    {
        this.CheckReadOnly();

        this.descriptors.Add(item);
    }

    public void Clear()
    {
        this.CheckReadOnly();

        this.descriptors.Clear();
    }

    public bool Contains(ServiceDescriptor item)
    {
        bool result = this.descriptors.Contains(item);

        return result;
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        this.descriptors.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        IEnumerator<ServiceDescriptor> enumerator = this.descriptors.GetEnumerator();
        
        return enumerator;
    }

    public int IndexOf(ServiceDescriptor item)
    {
        int index = this.descriptors.IndexOf(item);

        return index;
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        this.CheckReadOnly();

        this.descriptors.Insert(index, item);
    }

    public bool Remove(ServiceDescriptor item)
    {
        this.CheckReadOnly();

        bool result = this.descriptors.Remove(item);

        return result;
    }

    public void RemoveAt(int index)
    {
        this.CheckReadOnly();

        this.descriptors.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        IEnumerator enumerator = this.GetEnumerator();

        return enumerator;
    }

    public void MakeReadOnly()
    {
        this.isReadOnly = true;
    }

    private void CheckReadOnly()
    {
        if (this.isReadOnly)
        {
            throw new InvalidOperationException($"{nameof(ServiceCollection)} is read-only.");
        }
    }
}
