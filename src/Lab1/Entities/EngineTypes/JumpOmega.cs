using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;

[JumpEngine]
public class JumpOmega : IEngineType
{
    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(time * int.Log2(time));
    }
}