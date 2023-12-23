namespace Lab5.Application.Contracts.Accounts;

public abstract record AccountLoginResult
{
    private AccountLoginResult() { }

    public sealed record Success : AccountLoginResult;

    public sealed record Failure : AccountLoginResult;
}