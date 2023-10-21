using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class CoolingSystemValidationException : Exception
{
    public CoolingSystemValidationException()
    {
    }

    public CoolingSystemValidationException(string message)
        : base(message)
    {
    }

    public CoolingSystemValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}