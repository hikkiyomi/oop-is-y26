using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Ram
    : IComponent,
    IPrototype<Ram>,
    IMemoryStorage,
    IPowerConsuming
{
    private readonly IList<RamState> _supportedStates;
    private readonly IList<XmpProfile> _profiles;

    public Ram(
        double memory,
        IEnumerable<RamState> supportedStates,
        IEnumerable<XmpProfile> profiles,
        IFormFactor formFactor,
        IDdrStandard ddrStandard,
        int voltage)
    {
        Memory = memory;
        _supportedStates = supportedStates.ToList();
        _profiles = profiles.ToList();
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        Voltage = voltage;
    }

    public double Memory { get; }
    public IReadOnlyCollection<RamState> SupportedStates => _supportedStates.AsReadOnly();
    public IReadOnlyCollection<XmpProfile> Profiles => _profiles.AsReadOnly();
    public IFormFactor FormFactor { get; }
    public IDdrStandard DdrStandard { get; }
    public int Voltage { get; }

    public Ram Clone()
    {
        return new Ram(
            Memory,
            _supportedStates,
            _profiles,
            FormFactor,
            DdrStandard,
            Voltage);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}