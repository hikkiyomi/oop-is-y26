using Itmo.ObjectOrientedProgramming.Lab1.Common;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;

public interface IFuelConsuming
{
    EngineResult ConsumeFuel(int distance);
}