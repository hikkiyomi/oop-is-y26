namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record FormFactor : IComponentPart
{
    public abstract string Name { get; }
}