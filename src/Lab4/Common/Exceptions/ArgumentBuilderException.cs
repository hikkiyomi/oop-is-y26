using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class ArgumentBuilderException : Exception
{
    public ArgumentBuilderException()
    {
    }

    public ArgumentBuilderException(string message)
        : base(message)
    {
    }

    public ArgumentBuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}