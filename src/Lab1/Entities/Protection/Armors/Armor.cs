using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public abstract class Armor : IBreakable
{
    protected Armor(int health, ReadOnlyDictionary<DamageSource, double> coefficients)
    {
        Health = new HealthPoints(health);
        Coefficients = coefficients;
    }

    public HealthPoints Health { get; private set; }
    public bool IsBroken => Health.Value == 0;
    private ReadOnlyDictionary<DamageSource, double> Coefficients { get; }

    public DamageResult TakeHit(DamageInfo damageInfo)
    {
        if (IsBroken)
        {
            return new DamageResult.Destroyed();
        }

        if (damageInfo.DamageSource is DamageSource.CosmoWhale)
        {
            Health = new HealthPoints(0);
        }
        else
        {
            var realDamage = new HealthPoints((int)(damageInfo.Damage.Value * Coefficients[damageInfo.DamageSource]));
            Health = new HealthPoints(int.Max(Health.Value - realDamage.Value, 0));
        }

        return IsBroken switch
        {
            true => new DamageResult.Destroyed(),
            false => new DamageResult.Success(),
        };
    }
}