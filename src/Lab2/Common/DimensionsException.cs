using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public class DimensionsException : Exception
{
    public DimensionsException()
    {
    }

    public DimensionsException(string message)
        : base(message)
    {
    }

    public DimensionsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}