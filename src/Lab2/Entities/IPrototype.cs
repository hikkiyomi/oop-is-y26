namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPrototype<out T>
    where T : IPrototype<T>
{
    T Clone();
}