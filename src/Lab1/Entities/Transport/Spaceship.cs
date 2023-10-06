using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public abstract class Spaceship : ITravelSuitable, IHittable
{
    protected Spaceship(
        IReadOnlyCollection<Engine> engines,
        Deflector? deflector,
        Armor armor,
        ShipModification? shipModification)
    {
        Engines = engines;
        ShipModification = shipModification;
        Deflector = deflector;
        Armor = armor;
    }

    public IReadOnlyCollection<Engine> Engines { get; }
    private ShipModification? ShipModification { get; }
    private Deflector? Deflector { get; }
    private Armor Armor { get; }

    public void Travel()
    {
        throw new System.NotImplementedException();
    }

    public TravelResult TakeHit(DamageInfo damageInfo)
    {
        return damageInfo.DamageType switch
        {
            DamageType.Physical => DealPhysicalDamage(damageInfo),
            DamageType.Pure => DealPureDamage(damageInfo),
            DamageType.Critical => DealCriticalDamage(damageInfo),
            _ => throw new ShipException("Trying to deal unknown type of damage"),
        };
    }

    private TravelResult DealPhysicalDamage(DamageInfo damageInfo)
    {
        return Deflector is not null
            ? Deflector.TakeHit(damageInfo)
            : Armor.TakeHit(damageInfo);
    }

    private TravelResult DealPureDamage(DamageInfo damageInfo)
    {
        if (Deflector is null
            || Deflector.IsBroken
            || Deflector.Modification is not PhotonDeflector)
        {
            return new TravelResult.CrewDeath();
        }

        return Deflector.Modification.TakeHit(damageInfo);
    }

    private TravelResult DealCriticalDamage(DamageInfo damageInfo)
    {
        return ShipModification is not AntiNeutrinoEmitter ? DealPhysicalDamage(damageInfo) : new TravelResult.Success();
    }
}