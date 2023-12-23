namespace Lab5.Application.Models.Operations;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record Success : OperationResult;

    public sealed record Failure : OperationResult;
}