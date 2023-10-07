using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class JumpClassOmega : Engine
{
    public JumpClassOmega()
        : base(
            new LogarithmicConsume(),
            new Fuel(10),
            EngineType.Jump)
    {
    }
}