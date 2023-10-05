using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection;

public interface IDamageable
{
    HealthPoints Health { get; }

    void TakeDamage();
}