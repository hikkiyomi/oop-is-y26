using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;

public class PhotonDeflector : DeflectorModification
{
    private const int DefaultHealth = 3;

    public PhotonDeflector()
        : base(DefaultHealth)
    {
    }

    public override TravelResult TakeHit(DamageInfo damageInfo)
    {
        if (IsBroken)
        {
            return new TravelResult.CrewDeath();
        }

        if (Health.Value <= damageInfo.Damage.Value)
        {
            Health = new HealthPoints(0);
        }
        else
        {
            Health -= damageInfo.Damage;
        }

        return new TravelResult.Success();
    }
}