namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class LinearConsume : IFuelConsumptionFunction, ILimited
{
    public int Limit => 20;

    public int FuelConsumptionPerTimeUnit => 5;

    public ConsumptionResult CalculateFuelConsumption(int distance)
        => new ConsumptionResult(
            distance,
            distance * FuelConsumptionPerTimeUnit);
}