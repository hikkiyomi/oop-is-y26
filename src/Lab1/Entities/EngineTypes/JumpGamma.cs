using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineTypes;

[JumpEngine]
public class JumpGamma : IEngineType
{
    public Fuel CalculateFuelConsumption(int time)
    {
        return new Fuel(time * time);
    }
}