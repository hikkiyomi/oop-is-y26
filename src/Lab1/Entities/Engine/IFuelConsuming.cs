namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IFuelConsuming
{
    public bool TryConsumeFuel(int timePassed);
}