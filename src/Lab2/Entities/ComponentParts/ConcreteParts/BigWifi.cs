namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts.ConcreteParts;

public class BigWifi : IWifiModule
{
    public string Name => "BigWifi";
    public int Voltage => 50;
    public IWifiStandard Standard => new Wifi50();
    public bool HasBluetooth => true;
    public string PciVersion => "3.0";
}