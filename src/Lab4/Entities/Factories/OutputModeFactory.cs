using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;

public class OutputModeFactory
{
    private int _instancesCreated;

    public IOutputMode Create(string type)
    {
        ++_instancesCreated;

        return type switch
        {
            "console" => new ConsoleMode(),
            _ => throw new OutputModeFactoryException("Trying to use unknown output mode."),
        };
    }
}