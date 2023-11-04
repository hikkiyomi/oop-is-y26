using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;

public class MessageIsReadException : Exception
{
    public MessageIsReadException()
    {
    }

    public MessageIsReadException(string message)
        : base(message)
    {
    }

    public MessageIsReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}