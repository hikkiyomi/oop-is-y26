using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;

public abstract class Engine : IFuelConsuming
{
    private const int MoneyPerFuelUnit = 1;
    private readonly IFuelConsumptionFunction _engineFuelConsumer;

    protected Engine(
        IFuelConsumptionFunction engineFuelConsumer,
        EngineType type)
    {
        _engineFuelConsumer = engineFuelConsumer;
        Type = type;
    }

    public EngineType Type { get; }

    public EngineResult ConsumeFuel(int distance)
    {
        if (_engineFuelConsumer is ILimited limitedEngine)
        {
            if (distance > limitedEngine.Limit)
            {
                return new EngineResult.LostInSpace();
            }
        }

        ConsumptionResult consumeResult = _engineFuelConsumer.CalculateFuelConsumption(distance);

        return new EngineResult.Success(
            consumeResult.TimeSpent,
            consumeResult.FuelSpent * MoneyPerFuelUnit);
    }
}