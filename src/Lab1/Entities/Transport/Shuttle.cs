using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Shuttle : Spaceship
{
    public Shuttle()
        : base(
            new[]
            {
                new Engine(
                    new ConstantConsume(),
                    new Fuel(10),
                    EngineType.Impulse),
            },
            null,
            new ArmorClass1())
    {
    }
}