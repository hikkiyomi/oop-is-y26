using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineCharacteristics;

public class ConstantConsume : IFuelConsumptionFunction
{
    private const int FuelConsumption = 5;

    public EngineType Type => EngineType.Impulse;

    public Fuel CalculateFuelConsumption(int time) => new Fuel(FuelConsumption);
}