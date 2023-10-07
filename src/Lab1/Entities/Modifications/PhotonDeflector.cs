using Itmo.ObjectOrientedProgramming.Lab1.Common;
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

    public override DamageResult TakeHit(DamageInfo damageInfo)
    {
        if (IsBroken)
        {
            return new DamageResult.CrewDeath();
        }

        Health = new HealthPoints(int.Max(Health.Value - damageInfo.Damage.Value, 0));

        return new DamageResult.Success();
    }
}