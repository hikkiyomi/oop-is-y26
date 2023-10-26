namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class PowerSupply : IComponent, IPrototype<PowerSupply>
{
    public PowerSupply(int maxVoltage)
    {
        MaxVoltage = maxVoltage;
    }

    public int MaxVoltage { get; }

    public PowerSupply Clone()
    {
        return new PowerSupply(MaxVoltage);
    }

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(PowerSupply other)
    {
        return MaxVoltage == other.MaxVoltage;
    }
}