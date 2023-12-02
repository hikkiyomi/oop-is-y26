using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class ParserContextException : Exception
{
    public ParserContextException()
    {
    }

    public ParserContextException(string message)
        : base(message)
    {
    }

    public ParserContextException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}