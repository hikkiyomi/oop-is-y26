namespace Lab5.Application.Contracts.Users;

public abstract record SignupResult
{
    private SignupResult() { }

    public sealed record Success : SignupResult;

    public sealed record Failure : SignupResult;
}