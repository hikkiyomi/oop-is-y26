using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class CoolingSystemBuilder : IComponentBuilder
{
    private readonly List<Socket> _supportedSockets = new List<Socket>();
    private Dimensions? _size;
    private int? _maxTdp;

    public void Reset()
    {
        _supportedSockets.Clear();
        _size = null;
        _maxTdp = null;
    }

    public CoolingSystemBuilder SetSize(
        int length,
        int width,
        int height)
    {
        _size = new Dimensions(length, width, height);

        return this;
    }

    public CoolingSystemBuilder AddSocket(Socket socket)
    {
        _supportedSockets.Add(socket);

        return this;
    }

    public CoolingSystemBuilder SetMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;

        return this;
    }

    public IComponent Build()
    {
        var coolingSystem = new CoolingSystem(
            _size ?? throw new CoolingSystemValidationException("Cooling system should have sizes"),
            _supportedSockets,
            _maxTdp ?? throw new CoolingSystemValidationException("Cooling system should have a maximum TDP"));

        Reset();

        return coolingSystem;
    }
}