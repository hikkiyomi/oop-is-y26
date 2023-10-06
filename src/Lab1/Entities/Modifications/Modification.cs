using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;

public abstract class Modification : IDamageable
{
    protected Modification(int health)
    {
        Health = new HealthPoints(health);
    }

    public HealthPoints Health { get; protected set; }

    public abstract void TakeDamage();
}