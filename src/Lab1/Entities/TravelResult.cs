namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract record TravelResult
{
    private TravelResult() { }

    public sealed record Success : TravelResult;
    public sealed record LostInSpace : TravelResult;
    public sealed record Destroyed : TravelResult;
    public sealed record CrewDeath : TravelResult;
}