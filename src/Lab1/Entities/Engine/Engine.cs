using Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class Engine : IFuelConsuming
{
    private readonly IConsumptionFunction _consumption;

    public Engine(EngineType engineType)
    {
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

    public int Fuel { get; private set; }

    public bool TryConsumeFuel(int timePassed)
    {
        int fuelNeeded = _consumption.CalculateFuelConsumption(timePassed);

        if (Fuel < fuelNeeded)
        {
            return false;
        }

        Fuel -= fuelNeeded;

        return true;
    }
}