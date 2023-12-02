using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

public class FileSystemFactoryException : Exception
{
    public FileSystemFactoryException()
    {
    }

    public FileSystemFactoryException(string message)
        : base(message)
    {
    }

    public FileSystemFactoryException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}