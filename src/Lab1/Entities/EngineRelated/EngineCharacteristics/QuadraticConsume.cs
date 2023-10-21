namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class QuadraticConsume : IFuelConsumptionFunction, ILimited
{
    public int Limit => 100;
    public int FuelConsumptionPerTimeUnit => 5;

    public ConsumptionResult CalculateFuelConsumption(int distance)
        => new ConsumptionResult(
            distance,
            distance * distance * FuelConsumptionPerTimeUnit);
}