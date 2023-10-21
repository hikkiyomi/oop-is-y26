using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveSpeeds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

public class Hdd : IDrive, IPrototype<Hdd>
{
    public Hdd(
        IDriveConnection connection,
        int speed,
        double memory,
        int voltage)
    {
        Connection = connection;
        Speed = new HddSpeed(speed);
        Memory = memory;
        Voltage = voltage;
    }

    public IDriveConnection Connection { get; }
    public IDriveSpeed Speed { get; }
    public double Memory { get; }
    public int Voltage { get; }

    public Hdd Clone()
    {
        return new Hdd(
            Connection,
            Speed.PrimarySpeedInfo,
            Memory,
            Voltage);
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