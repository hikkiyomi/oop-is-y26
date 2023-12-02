using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class TransitionException : Exception
{
    public TransitionException()
    {
    }

    public TransitionException(string message)
        : base(message)
    {
    }

    public TransitionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}