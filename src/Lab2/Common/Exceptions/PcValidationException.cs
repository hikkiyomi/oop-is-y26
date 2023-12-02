using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class PcValidationException : Exception
{
    public PcValidationException()
    {
    }

    public PcValidationException(string message)
        : base(message)
    {
    }

    public PcValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}