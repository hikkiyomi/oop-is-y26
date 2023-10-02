using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class ConstantConsumption : IConsumptionFunction
{
    private const int FuelConsumption = 5;

    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(FuelConsumption);
    }
}