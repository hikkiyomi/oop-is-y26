using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class CombinerException : Exception
{
    public CombinerException()
    {
    }

    public CombinerException(string message)
        : base(message)
    {
    }

    public CombinerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}