using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public abstract class Deflector : IDamageable
{
    protected Deflector(HealthPoints health, DeflectorModification? deflectorModification)
    {
        Health = health;
        Modification = deflectorModification;
    }

    public HealthPoints Health { get; }
    public DeflectorModification? Modification { get; }

    public abstract void TakeDamage();
}