namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display
{
    private readonly IDisplayDriver _driver;

    void Display(string text);
}