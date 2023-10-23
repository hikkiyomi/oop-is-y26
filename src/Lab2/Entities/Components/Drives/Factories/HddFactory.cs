using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;

public class HddFactory : DriveFactory
{
    private readonly IDriveConnection _connection = new SataConnection();

    public override IDrive Create(
        int primarySpeedInfo,
        double memory,
        int voltage)
        => new Hdd(
            _connection,
            primarySpeedInfo,
            memory,
            voltage);
}