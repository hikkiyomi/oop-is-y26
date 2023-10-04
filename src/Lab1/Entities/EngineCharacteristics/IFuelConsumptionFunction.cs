using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineCharacteristics;

public interface IFuelConsumptionFunction
{
    EngineType Type { get; }

    Fuel CalculateFuelConsumption(int time);
}