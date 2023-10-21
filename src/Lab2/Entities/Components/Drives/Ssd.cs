using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveSpeeds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

public class Ssd : IDrive, IPrototype<Ssd>
{
    public Ssd(
        IDriveConnection connection,
        int readingSpeed,
        int writingSpeed,
        double memory,
        int voltage)
    {
        Connection = connection;
        Speed = new SsdSpeed(readingSpeed, writingSpeed);
        Memory = memory;
        Voltage = voltage;
    }

    public IDriveConnection Connection { get; }
    public SsdSpeed Speed { get; }
    public IDriveSpeed SpeedInfo => Speed;
    public double Memory { get; }
    public int Voltage { get; }

    public Ssd Clone()
    {
        return new Ssd(
            Connection,
            Speed.PrimarySpeedInfo,
            Speed.SecondarySpeedInfo,
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