namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;

public abstract class ShipModification : Modification
{
    protected ShipModification(int health)
        : base(health)
    {
    }
}