using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public sealed class Repository
{
    private static readonly Lazy<Repository> Instance
        = new Lazy<Repository>(
            () => new Repository(Array.Empty<IComponent>()),
            LazyThreadSafetyMode.ExecutionAndPublication);

    private readonly List<IComponent> _components;

    private Repository(IEnumerable<IComponent> components)
    {
        _components = components.ToList();
    }

    public static Repository GetInstance => Instance.Value;
    public void Add(IComponent component) => _components.Add(component);
    public IReadOnlyCollection<IComponent> GetComponents() => _components.AsReadOnly();
}