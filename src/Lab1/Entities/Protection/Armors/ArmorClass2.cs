using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public class ArmorClass2 : Armor
{
    private const int DefaultHealth = 3000;

    public ArmorClass2()
        : base(
            DefaultHealth,
            new CoefficientDto[]
            {
                new CoefficientDto() { Source = DamageSource.Asteroid, Coefficient = 1.0 },
                new CoefficientDto() { Source = DamageSource.Meteorite, Coefficient = 1.25 },
            })
    {
    }
}