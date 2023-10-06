using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : IObstacle
{
    public HealthPoints BaseDamage => new HealthPoints(600);
    public DamageType DamageType => DamageType.Physical;
    public DamageSource DamageSource => DamageSource.Asteroid;

    public void Hit(IHittable hittable)
    {
        hittable.TakeHit(new DamageInfo(BaseDamage, DamageType, DamageSource));
    }
}