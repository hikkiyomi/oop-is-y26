namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public static class DeflectorMaker
{
    public static Deflector Create<T>(DeflectorModification? deflectorModification)
        where T : Deflector, new()
    {
        return new T().Create(deflectorModification);
    }
}