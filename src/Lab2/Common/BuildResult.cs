namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public abstract record BuildResult
{
    private BuildResult() { }

    public sealed record Success : BuildResult;

    public sealed record Warning(string Commentary) : BuildResult;

    public sealed record WarrantyLoss(string Commentary) : BuildResult;

    public sealed record Incompatible : BuildResult;
}