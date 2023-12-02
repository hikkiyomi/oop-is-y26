namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record GraphicsCore : IComponentPart
{
    public abstract string Name { get; }
}