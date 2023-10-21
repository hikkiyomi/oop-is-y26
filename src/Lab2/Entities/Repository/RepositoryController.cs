using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public static class RepositoryController
{
    public static void Add(IComponent component)
    {
        Repository.GetInstance.Add(component);
    }

    public static IReadOnlyCollection<IPrototype<T>> Get<T>()
        where T : IPrototype<T>
    {
        IReadOnlyCollection<IComponent> components = Repository.GetInstance.GetComponents();

        return (IReadOnlyCollection<IPrototype<T>>)components.Where(x => x is T)
                                        .Select(x => (T)x)
                                        .ToList()
                                        .AsReadOnly();
    }
}