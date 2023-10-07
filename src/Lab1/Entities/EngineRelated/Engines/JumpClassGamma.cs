using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class JumpClassGamma : Engine
{
    public JumpClassGamma()
        : base(
            new QuadraticConsume(),
            new Fuel(10),
            EngineType.Jump)
    {
    }
}