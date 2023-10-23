namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts.ConcreteParts;

public record BigWifi : WifiModule
{
    public override string Name => "BigWifi";
    public override int Voltage => 50;
    public override WifiStandard Standard => new Wifi50();
    public override bool HasBluetooth => true;
    public override string PciVersion => "3.0";
}