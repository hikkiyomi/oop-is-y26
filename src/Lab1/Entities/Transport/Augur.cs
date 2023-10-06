using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Augur : Spaceship
{
    public Augur(DeflectorModification? deflectorModification)
        : base(
            engines: new[]
            {
                new Engine(
                    new ExponentialConsume(),
                    new Fuel(10),
                    EngineType.Impulse),
                new Engine(
                    new LinearConsume(),
                    new Fuel(10),
                    EngineType.Jump),
            },
            deflector: new DeflectorClass3(deflectorModification),
            armor: new ArmorClass3(),
            shipModification: null)
    {
    }
}