using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;

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

    private IReadOnlyCollection<Engine> Engines { get; }
    private ShipModification? ShipModification { get; }
    private Deflector? Deflector { get; }
    private Armor Armor { get; }

    public TravelResult Travel(IRouteSegment segment)
    {
        foreach (IObstacle obstacle in segment.Environment.Obstacles)
        {
            DamageResult damageResult = obstacle.Hit(this);

            TravelResult? obstacleDamageResult = damageResult switch
            {
                DamageResult.Destroyed => new TravelResult.Destroyed(),
                DamageResult.CrewDeath => new TravelResult.CrewDeath(),
                _ => null,
            };

            if (obstacleDamageResult is TravelResult.Destroyed or TravelResult.CrewDeath)
            {
                return obstacleDamageResult;
            }
        }

        TravelResult? result = null;

        foreach (Engine engine in Engines)
        {
            if (!engine.Type.Equals(segment.Environment.EngineRestriction)) continue;

            EngineResult engineResult = engine.ConsumeFuel(segment.Distance);

            if (engineResult is EngineResult.Success successfulResult)
            {
                result = new TravelResult.Success(
                    successfulResult.TimeSpent,
                    successfulResult.MoneySpent);
            }
            else
            {
                result = new TravelResult.LostInSpace();
            }

            break;
        }

        if (result is null)
        {
            throw new ShipException(
                "No suitable engine found.");
        }

        return result;
    }

    public DamageResult TakeHit(DamageInfo damageInfo)
    {
        return damageInfo.DamageType switch
        {
            DamageType.Physical => DealPhysicalDamage(damageInfo),
            DamageType.Pure => DealPureDamage(damageInfo),
            DamageType.Critical => DealCriticalDamage(damageInfo),
            _ => throw new ShipException("Trying to deal unknown type of damage"),
        };
    }

    private DamageResult DealPhysicalDamage(DamageInfo damageInfo)
    {
        return Deflector is not null && !Deflector.IsBroken
            ? Deflector.TakeHit(damageInfo)
            : Armor.TakeHit(damageInfo);
    }

    private DamageResult DealPureDamage(DamageInfo damageInfo)
    {
        if (Deflector is null
            || Deflector.IsBroken
            || Deflector.Modification is not PhotonDeflector)
        {
            return new DamageResult.CrewDeath();
        }

        return Deflector.Modification.TakeHit(damageInfo);
    }

    private DamageResult DealCriticalDamage(DamageInfo damageInfo)
    {
        return ShipModification is not AntiNeutrinoEmitter
            ? DealPhysicalDamage(damageInfo)
            : ShipModification.TakeHit(damageInfo);
    }
}