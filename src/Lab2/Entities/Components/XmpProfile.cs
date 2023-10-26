using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class XmpProfile : IComponent, IPrototype<XmpProfile>
{
    public XmpProfile(
        int cl,
        int trcd,
        int trp,
        int tras,
        double frequency,
        int voltage)
    {
        Timings = new RamTimings(cl, trcd, trp, tras);
        State = new RamState(frequency, voltage);
    }

    public RamTimings Timings { get; }
    public RamState State { get; }

    public XmpProfile Clone()
    {
        return new XmpProfile(
            Timings.Cl,
            Timings.Trcd,
            Timings.Trp,
            Timings.Tras,
            State.Frequency,
            State.Voltage);
    }

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(XmpProfile other)
    {
        return Timings == other.Timings
               && State == other.State;
    }
}