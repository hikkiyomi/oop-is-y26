namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveSpeeds;

public record SsdSpeed(
    int PrimarySpeedInfo,
    int SecondarySpeedInfo) : IDriveSpeed;