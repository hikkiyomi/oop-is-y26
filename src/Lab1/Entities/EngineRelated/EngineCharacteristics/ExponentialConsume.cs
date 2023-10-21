namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class ExponentialConsume : IFuelConsumptionFunction
{
    public int FuelConsumptionPerTimeUnit => 5;

    public ConsumptionResult CalculateFuelConsumption(int distance)
        => new ConsumptionResult(
            int.Log2(distance),
            int.Log2(distance) * FuelConsumptionPerTimeUnit);
}