using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public class ArmorClass2 : Armor
{
    private const int DefaultHealth = 3000;

    public ArmorClass2()
        : base(
            DefaultHealth,
            new ReadOnlyDictionary<DamageSource, double>(
                new Dictionary<DamageSource, double>()
                {
                    { DamageSource.Asteroid, 1.0 },
                    { DamageSource.Meteorite, 1.25 },
                }))
    {
    }
}