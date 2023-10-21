using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class JumpClassGamma : Engine
{
    public JumpClassGamma()
        : base(
            new QuadraticConsume(),
            EngineType.Jump)
    {
    }
}