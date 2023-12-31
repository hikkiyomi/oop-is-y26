namespace Lab5.Application.Exceptions;

public class UserHandlerException : Exception
{
    public UserHandlerException()
    {
    }

    public UserHandlerException(string message)
        : base(message)
    {
    }

    public UserHandlerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}