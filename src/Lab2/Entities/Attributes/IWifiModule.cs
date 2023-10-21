namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Attributes;

public interface IWifiModule : IComponentPart, IPowerConsuming
{
    IWifiStandard Standard { get; }
    bool HasBluetooth { get; }
    string PciVersion { get; }
}