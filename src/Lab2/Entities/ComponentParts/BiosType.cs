namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record BiosType : IComponentPart
{
    public abstract string Name { get; }
}