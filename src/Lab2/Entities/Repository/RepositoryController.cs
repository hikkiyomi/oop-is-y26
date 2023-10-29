using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public class RepositoryController
{
    private readonly Repository _repository = Repository.GetInstance();

    public void Add(int id, IComponent component)
    {
        if (id <= 0)
        {
            throw new RepositoryException(
                "Trying to add a component with improper id.");
        }

        _repository.Add(new Product(id, component));
    }

    public T GetById<T>(int id)
        where T : class, IComponent
    {
        IComponent? component = _repository.FindComponentById(id);

        if (component is null)
        {
            throw new RepositoryException(
                "There is no component in repository with such id.");
        }

        return component as T
               ?? throw new RepositoryException("The component with provided id has another type.");
    }
}