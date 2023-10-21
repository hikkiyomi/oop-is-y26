using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveSpeeds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

public interface IDrive
    : IComponent,
    IPrototype<IDrive>,
    IMemoryStorage,
    IPowerConsuming
{
    IDriveConnection Connection { get; }
    IDriveSpeed SpeedInfo { get; }
}