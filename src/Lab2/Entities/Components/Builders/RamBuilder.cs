using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class RamBuilder : IComponentBuilder
{
    private readonly List<RamState> _supportedStates = new List<RamState>();
    private readonly List<XmpProfile> _profiles = new List<XmpProfile>();
    private double? _memory;
    private FormFactor? _formFactor;
    private DdrStandard? _ddrStandard;
    private int? _voltage;

    public void Reset()
    {
        _supportedStates.Clear();
        _profiles.Clear();
        _memory = null;
        _formFactor = null;
        _ddrStandard = null;
        _voltage = null;
    }

    public RamBuilder SetMemory(double memory)
    {
        _memory = memory;

        return this;
    }

    public RamBuilder AddSupportedState(double frequency, int voltage)
    {
        _supportedStates.Add(new RamState(frequency, voltage));

        return this;
    }

    public RamBuilder AddXmpProfile(
        int cl,
        int trcd,
        int trp,
        int tras,
        double frequency,
        int voltage)
    {
        _profiles.Add(new XmpProfile(cl, trcd, trp, tras, frequency, voltage));

        return this;
    }

    public RamBuilder SetFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public RamBuilder SetDdrStandard(DdrStandard ddrStandard)
    {
        _ddrStandard = ddrStandard;

        return this;
    }

    public RamBuilder SetVoltage(int voltage)
    {
        _voltage = voltage;

        return this;
    }

    public IComponent Build()
    {
        var ram = new Ram(
            _memory ?? throw new RamValidationException("RAM should have memory assigned."),
            _supportedStates,
            _profiles,
            _formFactor ?? throw new RamValidationException("RAM should have form factor assigned."),
            _ddrStandard ?? throw new RamValidationException("RAM should have DDR standard assigned."),
            _voltage ?? throw new RamValidationException("RAM should have voltage assigned."));

        Reset();

        return ram;
    }
}