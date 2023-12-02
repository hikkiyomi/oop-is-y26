using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class PathException : Exception
{
    public PathException()
    {
    }

    public PathException(string message)
        : base(message)
    {
    }

    public PathException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}