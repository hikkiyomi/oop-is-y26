using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;

public class DeflectorException : Exception
{
    public DeflectorException()
    {
    }

    public DeflectorException(string message)
        : base(message)
    {
    }

    public DeflectorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}