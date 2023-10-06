using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class DeflectorClass1 : Deflector
{
    private const int DefaultHealth = 1000;

    public DeflectorClass1(DeflectorModification? deflectorModification)
        : base(new HealthPoints(DefaultHealth), deflectorModification)
    {
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}