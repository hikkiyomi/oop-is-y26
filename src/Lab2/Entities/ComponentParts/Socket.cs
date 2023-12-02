namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record Socket : IComponentPart
{
    public abstract string Name { get; }
}