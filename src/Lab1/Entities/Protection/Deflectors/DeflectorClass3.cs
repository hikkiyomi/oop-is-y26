using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class DeflectorClass3 : Deflector
{
    private const int DefaultHealth = 10000;

    public DeflectorClass3()
    {
        Health = new HealthPoints(0);
        Modification = null;
    }

    private DeflectorClass3(int health, DeflectorModification? modification)
    {
        Health = new HealthPoints(health);
        Modification = modification;
    }

    public override HealthPoints Health { get; }
    public override DeflectorModification? Modification { get; }

    public override Deflector Create(DeflectorModification? modification)
    {
        return new DeflectorClass3(DefaultHealth, modification);
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}