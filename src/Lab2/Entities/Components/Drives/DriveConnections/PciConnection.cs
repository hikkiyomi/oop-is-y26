namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

public class PciConnection : IDriveConnection
{
    public PciConnection(string name)
    {
        Name = name;
    }

    public string Name { get; }
}