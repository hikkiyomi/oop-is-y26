using Itmo.ObjectOrientedProgramming.Lab1.Common;
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
            new CoefficientDto[]
            {
                new CoefficientDto() { Source = DamageSource.Asteroid, Coefficient = 1.0 },
                new CoefficientDto() { Source = DamageSource.Meteorite, Coefficient = 2.0 },
            })
    {
    }
}