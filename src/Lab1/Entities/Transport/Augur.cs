using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Augur : Spaceship
{
    public Augur(DeflectorModification? deflectorModification)
        : base(
            engines: new Engine[]
            {
                new ImpulseClassE(),
                new JumpClassAlpha(),
            },
            deflector: new DeflectorClass3(deflectorModification),
            armor: new ArmorClass3(),
            shipModification: null)
    {
    }
}