using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhale : IObstacle
{
    public HealthPoints BaseDamage => new HealthPoints(24000);
    public DamageType DamageType => DamageType.Critical;
    public DamageSource DamageSource => DamageSource.CosmoWhale;

    public DamageResult Hit(IHittable hittable)
    {
        return hittable.TakeHit(new DamageInfo(BaseDamage, DamageType, DamageSource));
    }
}