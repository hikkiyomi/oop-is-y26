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
        FormFactor formFactor,
        DdrStandard ddrStandard,
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
    public FormFactor FormFactor { get; }
    public DdrStandard DdrStandard { get; }
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

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}