using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public static class RepositoryController
{
    public static void Add(int id, IComponent component)
    {
        if (id <= 0)
        {
            throw new RepositoryException(
                "Trying to add a component with improper id.");
        }

        Repository.GetInstance.Add(new Product(id, component));
    }

    public static T GetById<T>(int id)
        where T : class, IComponent
    {
        IComponent component = Repository.GetInstance.GetComponent(id);
        var queryResult = component as T;

        return queryResult ?? throw new RepositoryException("The component with provided id has another type.");
    }
}