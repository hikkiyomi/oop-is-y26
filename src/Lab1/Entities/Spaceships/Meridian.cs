using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public class Meridian : Spaceship
{
    public Meridian()
        : base(
            new[]
            {
                new Engine(
                    new ExponentialConsume(),
                    new Fuel(10),
                    EngineType.Impulse),
            },
            DeflectorMaker.Create<DeflectorClass2>(new AntiNeutrinoEmitter()),
            new ArmorClass2())
    {
    }
}