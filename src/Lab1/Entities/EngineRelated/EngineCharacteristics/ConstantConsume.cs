using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public class ConstantConsume : IFuelConsumptionFunction
{
    private const int FuelConsumption = 5;

    public Fuel CalculateFuelConsumption(int time) => new(FuelConsumption);
}