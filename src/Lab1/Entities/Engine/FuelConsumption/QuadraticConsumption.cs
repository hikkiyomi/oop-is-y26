namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class QuadraticConsumption : IConsumptionFunction
{
    public int CalculateFuelConsumption(int time)
    {
        return time * time;
    }
}