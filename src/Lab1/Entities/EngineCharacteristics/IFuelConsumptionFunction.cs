using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;

public interface IFuelConsumptionFunction
{
    Fuel CalculateFuelConsumption(int time);
}