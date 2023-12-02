namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPrototype<out T> : IPrototypeBase
    where T : IPrototypeBase
{
    new T Clone();
}