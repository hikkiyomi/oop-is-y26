using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class DeflectorClass2 : Deflector
{
    private const int DefaultHealth = 3000;

    public DeflectorClass2(DeflectorModification? deflectorModification)
        : base(new HealthPoints(DefaultHealth), deflectorModification)
    {
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}