using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineCharacteristics;

public class LogarithmicConsume : IFuelConsumptionFunction
{
    public EngineType Type => EngineType.Jump;

    public Fuel CalculateFuelConsumption(int time) => new Fuel(time * int.Log2(time));
}