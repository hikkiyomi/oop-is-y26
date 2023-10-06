namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;

public class AntiNeutrinoEmitter : ShipModification
{
    private const int DefaultHealth = 1;

    public AntiNeutrinoEmitter()
        : base(DefaultHealth)
    {
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}