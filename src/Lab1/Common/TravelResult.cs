namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract record TravelResult
{
    private TravelResult() { }

    public sealed record Success(int TimeSpent, int MoneySpent) : TravelResult;
    public sealed record LostInSpace : TravelResult;
    public sealed record Destroyed : TravelResult;
    public sealed record CrewDeath : TravelResult;
}