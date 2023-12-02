using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;

public class SsdFactory : DriveFactory
{
    private readonly int _secondarySpeedInfo;
    private readonly IDriveConnection _connection;

    public SsdFactory(int secondarySpeedInfo, IDriveConnection connection)
    {
        _secondarySpeedInfo = secondarySpeedInfo;
        _connection = connection;
    }

    public override IDrive Create(
        int primarySpeedInfo,
        double memory,
        int voltage)
    {
        return new Ssd(
            _connection,
            primarySpeedInfo,
            _secondarySpeedInfo,
            memory,
            voltage);
    }
}