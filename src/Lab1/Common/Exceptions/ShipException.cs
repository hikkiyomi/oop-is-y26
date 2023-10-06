using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;

public class ShipException : Exception
{
    public ShipException()
    {
    }

    public ShipException(string message)
        : base(message)
    {
    }

    public ShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}