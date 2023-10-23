namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record WifiStandard : IComponentPart
{
    public abstract string Name { get; }
    public abstract string Version { get; }
}