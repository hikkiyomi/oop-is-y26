using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public class ArmorClass3 : Armor
{
    private const int DefaultHealth = 12000;

    public ArmorClass3()
        : base(
            DefaultHealth,
            new ReadOnlyDictionary<DamageSource, double>(
                new Dictionary<DamageSource, double>()
                {
                    { DamageSource.Asteroid, 1.0 },
                    { DamageSource.Meteorite, 2.0 },
                }))
    {
    }
}