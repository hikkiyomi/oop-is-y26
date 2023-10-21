using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public class RamTimingsException : Exception
{
    public RamTimingsException()
    {
    }

    public RamTimingsException(string message)
        : base(message)
    {
    }

    public RamTimingsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}