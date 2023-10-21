using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Shuttle : Spaceship
{
    public Shuttle()
        : base(
            engines: new Engine[]
            {
                new ImpulseClassC(),
            },
            deflector: null,
            armor: new ArmorClass1(),
            shipModification: null)
    {
    }
}