namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public record ParameterContext
{
    public ParameterContext(string fullName)
    {
        ShortName = null;
        FullName = fullName;
    }

    public ParameterContext(
        string shortName,
        string fullName)
    {
        ShortName = shortName;
        FullName = fullName;
    }

    public string? ShortName { get; }
    public string FullName { get; }
}