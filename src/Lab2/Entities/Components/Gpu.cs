using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class Gpu
    : IComponent,
    IPrototype<Gpu>,
    ISized,
    IMemoryStorage,
    IPowerConsuming
{
    public Gpu(
        Dimensions size,
        double memory,
        string pciVersion,
        double frequency,
        int voltage)
    {
        Size = size;
        Memory = memory;
        PciVersion = pciVersion;
        Frequency = frequency;
        Voltage = voltage;
    }

    public Dimensions Size { get; }
    public double Memory { get; }
    public string PciVersion { get; }
    public double Frequency { get; }
    public int Voltage { get; }

    public Gpu Clone()
    {
        return new Gpu(
            Size,
            Memory,
            PciVersion,
            Frequency,
            Voltage);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(Gpu other)
    {
        return Size.Equals(other.Size)
               && Memory.Equals(other.Memory)
               && PciVersion == other.PciVersion
               && Frequency.Equals(other.Frequency)
               && Voltage == other.Voltage;
    }
}