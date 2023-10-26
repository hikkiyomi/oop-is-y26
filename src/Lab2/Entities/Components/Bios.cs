using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Bios : IComponent, IPrototype<Bios>
{
    private readonly IList<Cpu> _supportedCpu;

    public Bios(BiosType biosType, string version, IEnumerable<Cpu> supportedCpu)
    {
        BiosType = biosType;
        Version = version;
        _supportedCpu = supportedCpu.ToList();
    }

    public BiosType BiosType { get; }
    public string Version { get; }
    public IReadOnlyCollection<Cpu> SupportedCpu => _supportedCpu.AsReadOnly();

    public Bios Clone()
    {
        return new Bios(
            BiosType,
            Version,
            SupportedCpu);
    }

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(Bios other)
    {
        return _supportedCpu.SequenceEqual(other._supportedCpu)
               && BiosType.Equals(other.BiosType)
               && Version == other.Version;
    }
}