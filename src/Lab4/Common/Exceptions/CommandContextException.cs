using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class CommandContextException : Exception
{
    public CommandContextException()
    {
    }

    public CommandContextException(string message)
        : base(message)
    {
    }

    public CommandContextException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}