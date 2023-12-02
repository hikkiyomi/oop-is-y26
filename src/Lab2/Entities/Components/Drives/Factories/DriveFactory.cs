namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;

public abstract class DriveFactory
{
    public abstract IDrive Create(
        int primarySpeedInfo,
        double memory,
        int voltage);
}