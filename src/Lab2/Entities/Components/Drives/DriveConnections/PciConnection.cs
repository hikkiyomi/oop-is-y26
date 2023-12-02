namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

public record PciConnection : IDriveConnection
{
    public string Name => "PCI connection";
}