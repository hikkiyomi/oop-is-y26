using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public interface IChipset : IComponentPart
{
    IEnumerable<double> AvailableFrequencies { get; }
    bool IsXmpCompatible { get; }
}