using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class CoolingSystem : IComponent, IPrototype<CoolingSystem>, ISized
{
    private readonly IList<Socket> _supportedSockets;

    public CoolingSystem(Dimensions size, IEnumerable<Socket> supportedSockets, int maxTdp)
    {
        Size = size;
        _supportedSockets = supportedSockets.ToList();
        MaxTdp = maxTdp;
    }

    public Dimensions Size { get; }
    public IReadOnlyCollection<Socket> SupportedSockets => _supportedSockets.AsReadOnly();
    public int MaxTdp { get; }

    public CoolingSystem Clone()
    {
        return new CoolingSystem(
            Size,
            _supportedSockets,
            MaxTdp);
    }

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(CoolingSystem other)
    {
        return _supportedSockets.SequenceEqual(other._supportedSockets)
               && Size.Equals(other.Size)
               && MaxTdp == other.MaxTdp;
    }
}