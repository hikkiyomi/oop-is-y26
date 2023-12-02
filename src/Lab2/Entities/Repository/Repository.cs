using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

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

#pragma warning disable CA1024
    // Следующий код попадает под CA1024: Use properties where appropriate
    // Анализатор кода не даёт сделать это методом, потому что
    // GetInstance() не принимает аргументы и не возвращает какой-либо массив.
    // Поэтому единственный выход написать здесь метод, а не проперти -
    // это засуппрессить CA1024.
    public static Repository GetInstance() => Instance.Value;
#pragma warning restore CA1024

    public void Add(Product product)
    {
        if (product.Id <= 0)
        {
            throw new RepositoryException(
                "Trying to add a component with improper id.");
        }

        if (_components.ContainsKey(product.Id))
        {
            throw new RepositoryException(
                "Trying to add a component with occupied id.");
        }

        _components[product.Id] = product.Component;
    }

    public IComponent? FindComponentById(int id)
    {
        if (id <= 0)
        {
            throw new RepositoryException(
                "Trying to access a component with improper id.");
        }

        return _components.TryGetValue(id, out IComponent? component)
            ? component
            : null;
    }
}