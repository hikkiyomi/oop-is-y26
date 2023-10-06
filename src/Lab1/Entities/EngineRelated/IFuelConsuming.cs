namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;

public interface IFuelConsuming
{
    bool TryConsumeFuel(int timePassed);
}