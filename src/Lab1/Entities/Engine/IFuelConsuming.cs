namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IFuelConsuming
{
    bool TryConsumeFuel(int timePassed);
}