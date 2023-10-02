using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public interface IConsumptionFunction
{
    Fuel CalculateFuelConsumption(int time);
}