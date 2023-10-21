using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;

public class AntiNeutrinoEmitter : ShipModification
{
    private const int DefaultHealth = 1;

    public AntiNeutrinoEmitter()
        : base(DefaultHealth)
    {
    }

    public override DamageResult TakeHit(DamageInfo damageInfo)
    {
        return damageInfo.DamageSource is DamageSource.CosmoWhale
            ? new DamageResult.Success()
            : throw new DamageInfoException(
                "Unknown damage source for critical hit");
    }
}