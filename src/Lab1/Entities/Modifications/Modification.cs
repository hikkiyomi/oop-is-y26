using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;

public abstract class Modification : IBreakable
{
    protected Modification(int health)
    {
        Health = new HealthPoints(health);
    }

    public HealthPoints Health { get; protected set; }
    public bool IsBroken => Health.Value == 0;

    public abstract DamageResult TakeHit(DamageInfo damageInfo);
}