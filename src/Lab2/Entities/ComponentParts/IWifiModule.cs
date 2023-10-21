namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;

public interface IWifiModule : IComponentPart, IPowerConsuming
{
    IWifiStandard Standard { get; }
    bool HasBluetooth { get; }
    string PciVersion { get; }
}