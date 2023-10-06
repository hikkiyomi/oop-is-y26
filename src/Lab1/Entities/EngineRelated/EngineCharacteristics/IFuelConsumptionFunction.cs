using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

public interface IFuelConsumptionFunction
{
    Fuel CalculateFuelConsumption(int time);
}