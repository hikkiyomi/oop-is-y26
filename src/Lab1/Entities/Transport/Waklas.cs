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
            engines: new[]
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
            deflector: new DeflectorClass1(null),
            armor: new ArmorClass2(),
            shipModification: null)
    {
    }
}