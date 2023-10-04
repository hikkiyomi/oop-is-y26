using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineCharacteristics;

public class ExponentialConsume : IFuelConsumptionFunction
{
    public EngineType Type => EngineType.Impulse;

    public Fuel CalculateFuelConsumption(int time) => new Fuel(int.Log2(time));
}