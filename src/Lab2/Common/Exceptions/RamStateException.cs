using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class RamStateException : Exception
{
    public RamStateException()
    {
    }

    public RamStateException(string message)
        : base(message)
    {
    }

    public RamStateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}