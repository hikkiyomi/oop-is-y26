using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class ImpulseClassE : Engine
{
    public ImpulseClassE()
        : base(
            new ExponentialConsume(),
            new Fuel(10),
            EngineType.Impulse)
    {
    }
}