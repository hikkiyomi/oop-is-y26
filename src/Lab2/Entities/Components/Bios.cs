using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Bios : IComponent, IPrototype<Bios>
{
    private readonly IList<Cpu> _supportedCpu;

    public Bios(IBiosType biosType, string version, IEnumerable<Cpu> supportedCpu)
    {
        BiosType = biosType;
        Version = version;
        _supportedCpu = supportedCpu.ToList();
    }

    public IBiosType BiosType { get; }
    public string Version { get; }
    public IReadOnlyCollection<Cpu> SupportedCpu => _supportedCpu.AsReadOnly();

    public Bios Clone()
    {
        return new Bios(
            BiosType,
            Version,
            SupportedCpu);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}