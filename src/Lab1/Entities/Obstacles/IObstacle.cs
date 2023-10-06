using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public interface IObstacle
{
    HealthPoints BaseDamage { get; }
    DamageType DamageType { get; }
    DamageSource DamageSource { get; }

    void Hit(IHittable hittable);
}