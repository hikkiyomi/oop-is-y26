using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class ExponentialConsumption : IConsumptionFunction
{
    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(int.Log2(time));
    }
}