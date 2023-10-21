using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public class ArmorClass3 : Armor
{
    private const int DefaultHealth = 12000;

    public ArmorClass3()
        : base(
            DefaultHealth,
            new CoefficientDto[]
            {
                new CoefficientDto() { Source = DamageSource.Asteroid, Coefficient = 1.0 },
                new CoefficientDto() { Source = DamageSource.Meteorite, Coefficient = 2.0 },
            })
    {
    }
}