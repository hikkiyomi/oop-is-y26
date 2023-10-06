using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public abstract class Deflector : IDamageable
{
    public abstract HealthPoints Health { get; }
    public abstract DeflectorModification? Modification { get; }

    public abstract Deflector Create(DeflectorModification? modification);
    public abstract void TakeDamage();
}