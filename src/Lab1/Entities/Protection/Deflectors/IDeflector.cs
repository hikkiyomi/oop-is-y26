using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public interface IDeflector : IDamageable
{
    HealthPoints ModificationHealth { get; }

    IDeflector Create(int modificationHealth);
}