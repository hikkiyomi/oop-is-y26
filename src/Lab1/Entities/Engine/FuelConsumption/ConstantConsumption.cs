namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public class ConstantConsumption : IConsumptionFunction
{
    private const int FuelConsumption = 5;

    public int CalculateFuelConsumption(int time)
    {
        return FuelConsumption;
    }
}