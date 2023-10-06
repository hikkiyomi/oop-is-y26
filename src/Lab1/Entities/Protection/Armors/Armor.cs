using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public abstract class Armor : IDamageable
{
    protected Armor(int health)
    {
        Health = new HealthPoints(health);
    }

    public HealthPoints Health { get; private set; }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}