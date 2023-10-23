using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class GpuBuilder : IComponentBuilder
{
    private Dimensions? _size;
    private double? _memory;
    private string? _pciVersion;
    private double? _frequency;
    private int? _voltage;

    public void Reset()
    {
        _size = null;
        _memory = null;
        _pciVersion = null;
        _frequency = null;
        _voltage = null;
    }

    public GpuBuilder SetSize(int length, int width, int height)
    {
        _size = new Dimensions(length, width, height);

        return this;
    }

    public GpuBuilder SetMemory(double memory)
    {
        _memory = memory;

        return this;
    }

    public GpuBuilder SetPciVersion(string pciVersion)
    {
        _pciVersion = pciVersion;

        return this;
    }

    public GpuBuilder SetFrequency(double frequency)
    {
        _frequency = frequency;

        return this;
    }

    public GpuBuilder SetVoltage(int voltage)
    {
        _voltage = voltage;

        return this;
    }

    public IComponent Build()
    {
        return new Gpu(
            _size ?? throw new GpuValidationException("GPU should have sizes."),
            _memory ?? throw new GpuValidationException("GPU should have memory capacity."),
            _pciVersion ?? throw new GpuValidationException("GPU should have a PCI-E version."),
            _frequency ?? throw new GpuValidationException("GPU should have a frequency."),
            _voltage ?? throw new GpuValidationException("GPU should have a voltage."));
    }
}