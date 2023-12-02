using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record RamState
{
    public RamState(double frequency, int voltage)
    {
        if (frequency < 0)
        {
            throw new RamStateException(
                "Frequency of RAM cannot be negative.");
        }

        if (voltage < 0)
        {
            throw new RamStateException(
                "Voltage of RAM cannot be negative.");
        }

        Frequency = frequency;
        Voltage = voltage;
    }

    public double Frequency { get; }
    public int Voltage { get; }
}