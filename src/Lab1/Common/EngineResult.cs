namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract record EngineResult
{
    private EngineResult() { }

    public sealed record Success(int TimeSpent, int MoneySpent) : EngineResult;
    public sealed record LostInSpace : EngineResult;
}