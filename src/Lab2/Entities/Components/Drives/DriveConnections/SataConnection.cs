namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

public class SataConnection : IDriveConnection
{
    public SataConnection(string name)
    {
        Name = name;
    }

    public string Name { get; }
}