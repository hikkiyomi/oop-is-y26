namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class PhotonDeflector : DeflectorModification
{
    private const int DefaultHealth = 3;

    public PhotonDeflector()
        : base(DefaultHealth)
    {
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}