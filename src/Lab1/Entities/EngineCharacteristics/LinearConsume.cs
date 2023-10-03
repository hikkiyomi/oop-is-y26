using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;

[JumpEngine]
public class LinearConsume : IFuelConsumptionFunction
{
    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(time);
    }
}