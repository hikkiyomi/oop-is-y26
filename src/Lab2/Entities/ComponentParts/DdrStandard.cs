namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record DdrStandard : IComponentPart
{
    public abstract string Name { get; }
}