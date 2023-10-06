using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class DeflectorClass3 : Deflector
{
    private const int DefaultHealth = 10000;

    public DeflectorClass3(DeflectorModification? deflectorModification)
        : base(new HealthPoints(DefaultHealth), deflectorModification)
    {
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}