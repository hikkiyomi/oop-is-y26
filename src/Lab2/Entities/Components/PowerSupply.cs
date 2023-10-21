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

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}