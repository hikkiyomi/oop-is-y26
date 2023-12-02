using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class OutputModeFactoryException : Exception
{
    public OutputModeFactoryException()
    {
    }

    public OutputModeFactoryException(string message)
        : base(message)
    {
    }

    public OutputModeFactoryException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}