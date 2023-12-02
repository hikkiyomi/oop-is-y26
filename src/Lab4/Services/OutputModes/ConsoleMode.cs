using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

public class ConsoleMode : IOutputMode
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}