using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class DeflectorClass3 : Deflector
{
    private const int DefaultHealth = 24000;

    public DeflectorClass3(DeflectorModification? deflectorModification)
        : base(
            new HealthPoints(DefaultHealth),
            deflectorModification,
            new ReadOnlyDictionary<DamageSource, double>(new Dictionary<DamageSource, double>()
            {
                { DamageSource.Asteroid, 1.0 },
                { DamageSource.Meteorite, 2.0 },
            }))
    {
    }
}