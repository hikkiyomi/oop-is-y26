using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;

public class Engine : IFuelConsuming
{
    private readonly IFuelConsumptionFunction _engineFuelConsumer;
    private Fuel _fuel;

    public Engine(IFuelConsumptionFunction engineFuelConsumer, Fuel startingFuelCapacity, EngineType type)
    {
        _engineFuelConsumer = engineFuelConsumer;
        _fuel = startingFuelCapacity;
        Type = type;
    }

    public EngineType Type { get; }

    public bool TryConsumeFuel(int timePassed)
    {
        Fuel fuelNeeded = _engineFuelConsumer.CalculateFuelConsumption(timePassed);

        if (_fuel.Value < fuelNeeded.Value)
        {
            return false;
        }

        _fuel -= fuelNeeded;

        return true;
    }
}