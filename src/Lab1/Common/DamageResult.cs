namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract record DamageResult
{
    private DamageResult() { }

    public sealed record Success : DamageResult;
    public sealed record Destroyed : DamageResult;
    public sealed record CrewDeath : DamageResult;
}