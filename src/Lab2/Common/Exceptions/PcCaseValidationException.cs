using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class PcCaseValidationException : Exception
{
    public PcCaseValidationException()
    {
    }

    public PcCaseValidationException(string message)
        : base(message)
    {
    }

    public PcCaseValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}