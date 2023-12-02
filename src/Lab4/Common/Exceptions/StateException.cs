using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class StateException : Exception
{
    public StateException()
    {
    }

    public StateException(string message)
        : base(message)
    {
    }

    public StateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}