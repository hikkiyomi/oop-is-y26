namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public abstract record BuildResult(int Priority)
{
    private const int DefaultPriority = 0;

    private BuildResult()
        : this(DefaultPriority)
    {
    }

    public sealed record Success() :
        BuildResult(SuccessPriority)
    {
        private const int SuccessPriority = 1;
    }

    public sealed record Warning(string Commentary)
        : BuildResult(WarningPriority)
    {
        private const int WarningPriority = 2;
    }

    public sealed record WarrantyLoss(string Commentary)
        : BuildResult(WarrantyLossPriority)
    {
        private const int WarrantyLossPriority = 3;
    }

    public sealed record Incompatible(string Commentary) :
        BuildResult(IncompatiblePriority)
    {
        private const int IncompatiblePriority = 4;
    }
}