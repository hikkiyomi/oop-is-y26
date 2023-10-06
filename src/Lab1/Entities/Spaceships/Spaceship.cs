using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public abstract class Spaceship : ITravelSuitable
{
    protected Spaceship(IReadOnlyCollection<Engine> engines, Deflector? deflector, Armor armor)
    {
        Engines = engines;
        Deflector = deflector;
        Armor = armor;
    }

    public IReadOnlyCollection<Engine> Engines { get; }
    public Deflector? Deflector { get; }
    public Armor Armor { get; }

    public void Travel()
    {
        throw new System.NotImplementedException();
    }
}