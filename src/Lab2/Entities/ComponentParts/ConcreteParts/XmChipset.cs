using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts.ConcreteParts;

public class XmChipset : IChipset
{
    public string Name => "XM2210";

    public IEnumerable<double> AvailableFrequencies => new[]
    {
        1200.0, 1400.0, 1900.0, 3000.0, 4000.0,
    };

    public bool IsXmpCompatible => true;
}