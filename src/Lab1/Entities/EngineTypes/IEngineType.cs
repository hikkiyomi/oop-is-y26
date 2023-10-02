using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;

public interface IEngineType
{
    Fuel CalculateFuelConsumption(int time);
}