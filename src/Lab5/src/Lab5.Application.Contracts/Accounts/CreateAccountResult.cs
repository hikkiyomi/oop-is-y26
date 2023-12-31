namespace Lab5.Application.Contracts.Accounts;

public abstract record CreateAccountResult
{
    private CreateAccountResult() { }

    public sealed record Success : CreateAccountResult;

    public sealed record Failure : CreateAccountResult;
}