namespace Lab5.Application.Contracts.Exceptions;

public class LoginException : Exception
{
    public LoginException()
    {
    }

    public LoginException(string message)
        : base(message)
    {
    }

    public LoginException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}