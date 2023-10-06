using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Waklas : Spaceship
{
    public Waklas()
        : base(
            new[]
            {
                new Engine(
                    new ExponentialConsume(),
                    new Fuel(10),
                    EngineType.Impulse),
                new Engine(
                    new QuadraticConsume(),
                    new Fuel(10),
                    EngineType.Jump),
            },
            new DeflectorClass1(null),
            new ArmorClass1())
    {
    }
}