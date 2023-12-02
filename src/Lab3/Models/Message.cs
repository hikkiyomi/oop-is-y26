namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record Message(
    int Id,
    string Head,
    string Body)
{
    public override string ToString()
    {
        return $"Head: {Head}\nBody: {Body}";
    }
}