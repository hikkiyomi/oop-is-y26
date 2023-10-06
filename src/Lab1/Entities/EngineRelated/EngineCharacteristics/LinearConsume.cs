using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class LinearConsume : IFuelConsumptionFunction
{
    public Fuel CalculateFuelConsumption(int time) => new(time);
}