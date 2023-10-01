namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.FuelConsumption;

public interface IFuelConsuming
{
    bool TryConsumeFuel(int timePassed);
}