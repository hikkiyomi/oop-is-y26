using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;

[ImpulseEngine]
public class ImpulseE : IEngineType
{
    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(int.Log2(time));
    }
}