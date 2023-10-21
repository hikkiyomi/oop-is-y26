namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class LogarithmicConsume : IFuelConsumptionFunction, ILimited
{
    public int Limit => 50;
    public int FuelConsumptionPerTimeUnit => 5;

    public ConsumptionResult CalculateFuelConsumption(int distance)
        => new ConsumptionResult(
            distance,
            distance * int.Log2(distance) * FuelConsumptionPerTimeUnit);
}