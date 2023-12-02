using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class MotherboardValidationException : Exception
{
    public MotherboardValidationException()
    {
    }

    public MotherboardValidationException(string message)
        : base(message)
    {
    }

    public MotherboardValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}