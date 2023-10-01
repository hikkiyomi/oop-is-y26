namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class LinearConsumption : IConsumptionFunction
{
    public int CalculateFuelConsumption(int time)
    {
        return time;
    }
}