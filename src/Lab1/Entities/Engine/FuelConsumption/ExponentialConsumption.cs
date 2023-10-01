namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class ExponentialConsumption : IConsumptionFunction
{
    public int CalculateFuelConsumption(int time)
    {
        return int.Log2(time);
    }
}