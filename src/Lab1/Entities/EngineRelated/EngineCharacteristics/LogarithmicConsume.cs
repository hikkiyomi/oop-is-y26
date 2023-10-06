using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class LogarithmicConsume : IFuelConsumptionFunction
{
    public Fuel CalculateFuelConsumption(int time) => new(time * int.Log2(time));
}