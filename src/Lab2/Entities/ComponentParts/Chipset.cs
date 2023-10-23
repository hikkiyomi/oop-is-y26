using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record Chipset : IComponentPart
{
    public abstract string Name { get; }
    public abstract IEnumerable<double> AvailableFrequencies { get; }
    public abstract bool IsXmpCompatible { get; }
}