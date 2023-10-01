using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;

public class EngineException : Exception
{
    public EngineException()
        : base("Something with engine happened")
    {
    }

    public EngineException(string message)
        : base(message)
    {
    }

    public EngineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}