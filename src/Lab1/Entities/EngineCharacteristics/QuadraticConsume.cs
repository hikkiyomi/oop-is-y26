using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineCharacteristics;

public class QuadraticConsume : IFuelConsumptionFunction
{
    public EngineType Type => EngineType.Jump;

    public Fuel CalculateFuelConsumption(int time) => new Fuel(time * time);
}