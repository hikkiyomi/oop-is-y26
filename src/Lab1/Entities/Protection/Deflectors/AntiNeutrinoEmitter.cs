namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class AntiNeutrinoEmitter : DeflectorModification
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