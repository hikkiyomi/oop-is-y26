using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

public class GpuValidationException : Exception
{
    public GpuValidationException()
    {
    }

    public GpuValidationException(string message)
        : base(message)
    {
    }

    public GpuValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}