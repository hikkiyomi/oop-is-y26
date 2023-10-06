using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public abstract class DeflectorModification : IDamageable
{
    protected DeflectorModification(int health)
    {
        Health = new HealthPoints(health);
    }

    public HealthPoints Health { get; private set; }

    public abstract void TakeDamage();
}