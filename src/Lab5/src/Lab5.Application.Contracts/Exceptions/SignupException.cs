namespace Lab5.Application.Contracts.Exceptions;

public class SignupException : Exception
{
    public SignupException()
    {
    }

    public SignupException(string message)
        : base(message)
    {
    }

    public SignupException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}