using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class CpuValidationException : Exception
{
    public CpuValidationException()
    {
    }

    public CpuValidationException(string message)
        : base(message)
    {
    }

    public CpuValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}