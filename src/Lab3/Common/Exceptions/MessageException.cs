using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;

public class MessageException : Exception
{
    public MessageException()
    {
    }

    public MessageException(string message)
        : base(message)
    {
    }

    public MessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}