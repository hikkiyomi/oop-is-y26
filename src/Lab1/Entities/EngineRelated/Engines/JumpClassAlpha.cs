using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class JumpClassAlpha : Engine
{
    public JumpClassAlpha()
        : base(
            new LinearConsume(),
            EngineType.Jump)
    {
    }
}