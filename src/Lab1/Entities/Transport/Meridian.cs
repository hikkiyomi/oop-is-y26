using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Meridian : Spaceship
{
    public Meridian()
        : base(
            engines: new[]
            {
                new Engine(
                    new ExponentialConsume(),
                    new Fuel(10),
                    EngineType.Impulse),
            },
            deflector: new DeflectorClass2(null),
            armor: new ArmorClass2(),
            shipModification: new AntiNeutrinoEmitter())
    {
    }
}