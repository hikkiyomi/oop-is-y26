namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IFuelConsuming
{
    public bool TryConsumeFuel(int timePassed);
}