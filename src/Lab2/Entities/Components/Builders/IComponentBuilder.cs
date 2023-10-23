namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public interface IComponentBuilder
{
    void Reset();
    IComponent Build();
}