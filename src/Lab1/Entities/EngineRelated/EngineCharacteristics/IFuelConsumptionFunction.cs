namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public interface IFuelConsumptionFunction
{
    int FuelConsumptionPerTimeUnit { get; }

    ConsumptionResult CalculateFuelConsumption(int distance);
}