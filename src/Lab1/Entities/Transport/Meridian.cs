using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Meridian : Spaceship
{
    public Meridian()
        : base(
            engines: new Engine[]
            {
                new ImpulseClassE(),
            },
            deflector: new DeflectorClass2(null),
            armor: new ArmorClass2(),
            shipModification: new AntiNeutrinoEmitter())
    {
    }
}