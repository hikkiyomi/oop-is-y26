using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class DeflectorClass2 : Deflector
{
    private const int DefaultHealth = 3000;

    public DeflectorClass2()
    {
        Health = new HealthPoints(0);
        Modification = null;
    }

    private DeflectorClass2(int health, DeflectorModification? modification)
    {
        Health = new HealthPoints(health);
        Modification = modification;
    }

    public override HealthPoints Health { get; }
    public override DeflectorModification? Modification { get; }

    public override Deflector Create(DeflectorModification? modification)
    {
        return new DeflectorClass2(DefaultHealth, modification);
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}