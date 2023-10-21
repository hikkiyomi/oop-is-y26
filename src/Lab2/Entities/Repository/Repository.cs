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

    private readonly List<Product> _components;

    private Repository(IEnumerable<Product> components)
    {
        _components = components.ToList();
    }

    public static Repository GetInstance => Instance.Value;
    public void Add(Product component) => _components.Add(component);
    public IReadOnlyCollection<Product> GetComponents() => _components.AsReadOnly();
    public IComponent GetComponent(int id) => _components.First(component => component.Id == id).Component;
}