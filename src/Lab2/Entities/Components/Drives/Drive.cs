namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

public abstract class Drive : IComponent, IPrototype<Drive>, IMemoryUsing, IPowerConsuming
{
    protected Drive(
        IDriveConnection connection,
        IDriveSpeed maxSpeed,
        double memory,
        int voltage)
    {
        Connection = connection;
        MaxSpeed = maxSpeed;
        Memory = memory;
        Voltage = voltage;
    }

    public IDriveConnection Connection { get; }
    public IDriveSpeed MaxSpeed { get; }
    public double Memory { get; }
    public int Voltage { get; }

    public Drive Clone()
    {
        throw new System.NotImplementedException();
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }
}