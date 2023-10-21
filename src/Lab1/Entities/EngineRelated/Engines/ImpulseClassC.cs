using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class ImpulseClassC : Engine
{
    public ImpulseClassC()
        : base(
            new ConstantConsume(),
            EngineType.Impulse)
    {
    }
}