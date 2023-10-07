using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class ImpulseClassE : Engine
{
    public ImpulseClassE()
        : base(
            new ExponentialConsume(),
            EngineType.Impulse)
    {
    }
}