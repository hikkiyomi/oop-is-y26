using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public sealed class Repository
{
    private static readonly Lazy<Repository> Instance
        = new Lazy<Repository>(
            () => new Repository(Array.Empty<Product>()),
            LazyThreadSafetyMode.ExecutionAndPublication);

    private readonly Dictionary<int, IComponent> _components;

    private Repository(IEnumerable<Product> product)
    {
        _components = product.ToDictionary(
            components => components.Id,
            components => components.Component);
    }

    public static Repository GetInstance => Instance.Value;

    public void Add(Product product)
        => _components[product.Id] = product.Component;

    public IComponent GetComponent(int id) => _components[id];
}