using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public abstract class Deflector : IBreakable
{
    protected Deflector(HealthPoints health, DeflectorModification? deflectorModification, ReadOnlyDictionary<DamageSource, double> coefficients)
    {
        Health = health;
        Modification = deflectorModification;
        Coefficients = coefficients;
    }

    public HealthPoints Health { get; private set; }
    public DeflectorModification? Modification { get; }
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
            if (Health.Value >= damageInfo.Damage.Value)
            {
                Health = new HealthPoints(0);
            }
            else
            {
                return new DamageResult.Destroyed();
            }
        }
        else
        {
            var realDamage = new HealthPoints((int)(damageInfo.Damage.Value * Coefficients[damageInfo.DamageSource]));
            Health = new HealthPoints(int.Max(Health.Value - realDamage.Value, 0));
        }

        return new DamageResult.Success();
    }
}