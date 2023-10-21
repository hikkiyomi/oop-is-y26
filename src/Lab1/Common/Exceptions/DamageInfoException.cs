using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;

public class DamageInfoException : Exception
{
    public DamageInfoException()
    {
    }

    public DamageInfoException(string message)
        : base(message)
    {
    }

    public DamageInfoException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}