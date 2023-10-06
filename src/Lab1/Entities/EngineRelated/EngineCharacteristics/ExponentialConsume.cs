using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class ExponentialConsume : IFuelConsumptionFunction
{
    public Fuel CalculateFuelConsumption(int time) => new(int.Log2(time));
}