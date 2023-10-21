using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveSpeeds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

public class Ssd : IDrive, IPrototype<Ssd>
{
    public Ssd(
        IDriveConnection connection,
        int primarySpeedInfo,
        int secondarySpeedInfo,
        double memory,
        int voltage)
    {
        Connection = connection;
        Speed = new SsdSpeed(primarySpeedInfo, secondarySpeedInfo);
        Memory = memory;
        Voltage = voltage;
    }

    public IDriveConnection Connection { get; }
    public IDriveSpeed Speed { get; }
    public double Memory { get; }
    public int Voltage { get; }

    public Ssd Clone()
    {
        throw new System.NotImplementedException();
    }

    IDrive IPrototype<IDrive>.Clone()
    {
        return Clone();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}