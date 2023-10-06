using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : IObstacle
{
    public HealthPoints BaseDamage => new HealthPoints(1200);
    public DamageType DamageType => DamageType.Physical;
    public DamageSource DamageSource => DamageSource.Meteorite;

    public void Hit(IHittable hittable)
    {
        hittable.TakeHit(new DamageInfo(BaseDamage, DamageType, DamageSource));
    }
}