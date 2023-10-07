using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class JumpClassAlpha : Engine
{
    public JumpClassAlpha()
        : base(
            new LinearConsume(),
            new Fuel(10),
            EngineType.Jump)
    {
    }
}