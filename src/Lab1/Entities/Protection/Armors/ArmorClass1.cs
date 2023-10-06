using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public class ArmorClass1 : Armor
{
    private const int DefaultHealth = 600;

    public ArmorClass1()
        : base(
            DefaultHealth,
            new ReadOnlyDictionary<DamageSource, double>(
                new Dictionary<DamageSource, double>()
                {
                    { DamageSource.Asteroid, 1.0 },
                    { DamageSource.Meteorite, 1.0 },
                }))
    {
    }
}