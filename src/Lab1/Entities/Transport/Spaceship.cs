using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public abstract class Spaceship : ITravelSuitable
{
    protected Spaceship(
        IReadOnlyCollection<Engine> engines,
        Deflector? deflector,
        Armor armor,
        ShipModification? shipModification)
    {
        Engines = engines;
        Deflector = deflector;
        Armor = armor;
        ShipModification = shipModification;
    }

    public IReadOnlyCollection<Engine> Engines { get; }
    public Deflector? Deflector { get; }
    public Armor Armor { get; }
    public ShipModification? ShipModification { get; }

    public void Travel()
    {
        throw new System.NotImplementedException();
    }
}