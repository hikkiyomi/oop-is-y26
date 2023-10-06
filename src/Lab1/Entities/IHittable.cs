using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IHittable
{
    TravelResult TakeHit(DamageInfo damageInfo);
}