using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class CpuBuilder : IComponentBuilder
{
    private readonly List<double> _supportedMemoryFrequencies = new List<double>();
    private double? _frequency;
    private int? _cores;
    private ISocket? _socket;
    private IGraphicsCore? _graphicsCore;
    private int? _tdp;
    private int? _voltage;

    public CpuBuilder AddSupportedMemoryFrequency(double frequency)
    {
        _supportedMemoryFrequencies.Add(frequency);

        return this;
    }

    public CpuBuilder SetFrequency(double frequency)
    {
        _frequency = frequency;

        return this;
    }

    public CpuBuilder SetCoresAmount(int cores)
    {
        _cores = cores;

        return this;
    }

    public CpuBuilder SetSocket(ISocket socket)
    {
        _socket = socket;

        return this;
    }

    public CpuBuilder SetGraphicsCore(IGraphicsCore graphicsCore)
    {
        _graphicsCore = graphicsCore;

        return this;
    }

    public CpuBuilder SetTdp(int tdp)
    {
        _tdp = tdp;

        return this;
    }

    public CpuBuilder SetVoltage(int voltage)
    {
        _voltage = voltage;

        return this;
    }

    public IComponent Build()
    {
        return new Cpu(
            _frequency ?? throw new CpuValidationException("CPU should have a frequency"),
            _cores ?? throw new CpuValidationException("CPU should have at least one core"),
            _socket ?? throw new CpuValidationException("CPU should have a socket"),
            _graphicsCore,
            _supportedMemoryFrequencies,
            _tdp ?? throw new CpuValidationException("CPU should have a TDP"),
            _voltage ?? throw new CpuValidationException("CPU should have a voltage"));
    }
}