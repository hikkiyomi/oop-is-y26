namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPrototype<out T> // TODO: Better interface for this. Also for repository controller.
    where T : IPrototype<T>
{
    T Clone();
}