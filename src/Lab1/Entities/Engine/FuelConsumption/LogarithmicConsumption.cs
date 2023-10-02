using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class LogarithmicConsumption : IConsumptionFunction
{
    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(time * int.Log2(time));
    }
}