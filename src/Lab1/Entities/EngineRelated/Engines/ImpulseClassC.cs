using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;

public class ImpulseClassC : Engine
{
    public ImpulseClassC()
        : base(
            new ConstantConsume(),
            new Fuel(10),
            EngineType.Impulse)
    {
    }
}