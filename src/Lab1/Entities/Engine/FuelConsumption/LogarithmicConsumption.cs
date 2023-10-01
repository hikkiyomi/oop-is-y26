namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class LogarithmicConsumption : IConsumptionFunction
{
    public int CalculateFuelConsumption(int time)
    {
        return time * int.Log2(time);
    }
}