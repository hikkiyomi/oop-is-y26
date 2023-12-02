using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveSpeeds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

public class Hdd : IDrive, IPrototype<Hdd>
{
    public Hdd(
        IDriveConnection connection,
        int spindleSpeed,
        double memory,
        int voltage)
    {
        Connection = connection;
        Speed = new HddSpeed(spindleSpeed);
        Memory = memory;
        Voltage = voltage;
    }

    public IDriveConnection Connection { get; }
    public HddSpeed Speed { get; }
    public double Memory { get; }
    public int Voltage { get; }
    public IDriveSpeed SpeedInfo => Speed;

    public Hdd Clone()
    {
        return new Hdd(
            Connection,
            Speed.PrimarySpeedInfo,
            Memory,
            Voltage);
    }

    IPrototypeBase IPrototypeBase.Clone()
    {
        return Clone();
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