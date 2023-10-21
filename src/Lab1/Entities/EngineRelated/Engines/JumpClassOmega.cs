using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class JumpClassOmega : Engine
{
    public JumpClassOmega()
        : base(
            new LogarithmicConsume(),
            EngineType.Jump)
    {
    }
}