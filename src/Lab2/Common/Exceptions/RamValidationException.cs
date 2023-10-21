using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class RamValidationException : Exception
{
    public RamValidationException()
    {
    }

    public RamValidationException(string message)
        : base(message)
    {
    }

    public RamValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}