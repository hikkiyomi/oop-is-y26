using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Cpu : IComponent, IPrototype<Cpu>, IPowerConsuming
{
    private readonly IList<double> _supportedMemoryFrequencies;

    public Cpu(
        double frequency,
        int cores,
        ISocket socket,
        IGraphicsCore graphicsCore,
        IEnumerable<double> supportedMemoryFrequencies,
        int tdp,
        int voltage)
    {
        Frequency = frequency;
        Cores = cores;
        Socket = socket;
        GraphicsCore = graphicsCore;
        _supportedMemoryFrequencies = supportedMemoryFrequencies.ToList();
        Tdp = tdp;
        Voltage = voltage;
    }

    public double Frequency { get; }
    public int Cores { get; }
    public ISocket Socket { get; }
    public IGraphicsCore GraphicsCore { get; }
    public IReadOnlyCollection<double> MemoryFrequencies => _supportedMemoryFrequencies.AsReadOnly();
    public int Tdp { get; }
    public int Voltage { get; }

    public Cpu Clone()
    {
        return new Cpu(
            Frequency,
            Cores,
            Socket,
            GraphicsCore,
            _supportedMemoryFrequencies,
            Tdp,
            Voltage);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}