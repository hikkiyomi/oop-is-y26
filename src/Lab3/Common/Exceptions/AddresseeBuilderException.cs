using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;

public class AddresseeBuilderException : Exception
{
    public AddresseeBuilderException()
    {
    }

    public AddresseeBuilderException(string message)
        : base(message)
    {
    }

    public AddresseeBuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}