using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Engine : IFuelConsuming
{
    private readonly IEngineType _engineFuelConsumer;
    private Fuel _fuel;

    public Engine(IEngineType engineFuelConsumer, Fuel startingFuelCapacity)
    {
        _engineFuelConsumer = engineFuelConsumer;
        _fuel = startingFuelCapacity;
    }

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