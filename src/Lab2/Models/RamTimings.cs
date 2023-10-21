using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class RamTimings
{
    public RamTimings(int cl, int trcd, int trp, int tras)
    {
        if (cl < 0)
        {
            throw new RamTimingsException(
                "CAS Latency cannot be negative.");
        }

        if (trcd < 0)
        {
            throw new RamTimingsException(
                "RAS to CAS Delay cannot be negative.");
        }

        if (trp < 0)
        {
            throw new RamTimingsException(
                "Row Precharge Delay cannot be negative.");
        }

        if (tras < 0)
        {
            throw new RamTimingsException(
                "Activate to Precharge Delay cannot be negative.");
        }

        Cl = cl;
        Trcd = trcd;
        Trp = trp;
        Tras = tras;
    }

    public int Cl { get; }
    public int Trcd { get; }
    public int Trp { get; }
    public int Tras { get; }
}