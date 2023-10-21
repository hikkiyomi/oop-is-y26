namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;

public abstract class DriveFactory
{
    protected abstract IDrive Create(
        int primarySpeedInfo,
        double memory,
        int voltage);
}