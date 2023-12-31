namespace Lab5.Application.Contracts.Accounts;

public abstract record DepositResult
{
    private DepositResult() { }

    public sealed record Success : DepositResult;

    public sealed record Failure : DepositResult;
}