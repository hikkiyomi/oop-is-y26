using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntiMatterBlast : IObstacle
{
    public HealthPoints BaseDamage => new HealthPoints(1);
    public DamageType DamageType => DamageType.Pure;
    public DamageSource DamageSource => DamageSource.AntiMatterBlast;

    public void Hit(IHittable hittable)
    {
        hittable.TakeHit(new DamageInfo(BaseDamage, DamageType, DamageSource));
    }
}