namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

public record SataConnection : IDriveConnection
{
    public string Name => "SATA connection";
}