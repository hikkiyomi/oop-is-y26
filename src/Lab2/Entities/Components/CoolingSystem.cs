using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class CoolingSystem : IComponent, IPrototype<CoolingSystem>, ISized
{
    private readonly List<ISocket> _supportedSockets;

    public CoolingSystem(Dimensions size, IEnumerable<ISocket> supportedSockets, int maxTdp)
    {
        Size = size;
        _supportedSockets = supportedSockets.ToList();
        MaxTdp = maxTdp;
    }

    public Dimensions Size { get; }
    public IReadOnlyCollection<ISocket> SupportedSockets => _supportedSockets.AsReadOnly();
    public int MaxTdp { get; }

    public CoolingSystem Clone()
    {
        return new CoolingSystem(
            Size,
            _supportedSockets,
            MaxTdp);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}