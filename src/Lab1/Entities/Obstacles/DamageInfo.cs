using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public record DamageInfo(HealthPoints Damage, DamageType DamageType, DamageSource DamageSource);