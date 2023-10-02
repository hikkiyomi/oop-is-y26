using Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class Engine : IFuelConsuming
{
    private readonly IConsumptionFunction _consumption;
    private Fuel _fuel;

    public Engine(EngineType engineType, Fuel startingFuelCapacity)
    {
        _fuel = startingFuelCapacity;

        _consumption = engineType switch
        {
            EngineType.ImpulseC => new ConstantConsumption(),
            EngineType.ImpulseE => new ExponentialConsumption(),
            EngineType.JumpAlpha => new LinearConsumption(),
            EngineType.JumpOmega => new LogarithmicConsumption(),
            EngineType.JumpGamma => new QuadraticConsumption(),
            _ => throw new EngineException("Unexpected engine type"),
        };
    }

    public bool TryConsumeFuel(int timePassed)
    {
        Fuel fuelNeeded = _consumption.CalculateFuelConsumption(timePassed);

        if (_fuel.Value < fuelNeeded.Value)
        {
            return false;
        }

        _fuel -= fuelNeeded;

        return true;
    }
}