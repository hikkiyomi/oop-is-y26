namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class ConstantConsume : IFuelConsumptionFunction
{
    private const int Velocity = 5;

    public int FuelConsumptionPerTimeUnit => 2;

    public ConsumptionResult CalculateFuelConsumption(int distance)
        => new ConsumptionResult(
            distance / Velocity,
            distance / Velocity * FuelConsumptionPerTimeUnit);
}