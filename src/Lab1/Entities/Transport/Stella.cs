using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Stella : Spaceship
{
    public Stella(DeflectorModification? deflectorModification)
        : base(
            engines: new Engine[]
            {
                new ImpulseClassC(),
                new JumpClassOmega(),
            },
            deflector: new DeflectorClass1(deflectorModification),
            armor: new ArmorClass1(),
            shipModification: null)
    {
    }
}