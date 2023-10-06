namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;

public class ArmorClass1 : Armor
{
    private const int DefaultHealth = 500;

    public ArmorClass1()
        : base(DefaultHealth)
    {
    }
}