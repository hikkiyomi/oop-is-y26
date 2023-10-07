using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IHittable
{
    DamageResult TakeHit(DamageInfo damageInfo);
}