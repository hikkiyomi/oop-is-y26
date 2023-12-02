namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public abstract record WifiModule : IComponentPart, IPowerConsuming
{
    public abstract string Name { get; }
    public abstract int Voltage { get; }
    public abstract WifiStandard Standard { get; }
    public abstract bool HasBluetooth { get; }
    public abstract string PciVersion { get; }
}