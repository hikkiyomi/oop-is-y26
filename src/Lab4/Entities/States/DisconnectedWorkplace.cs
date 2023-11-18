using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class DisconnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly Parser _parser;

    public DisconnectedWorkplace(Workplace workplace)
    {
        _workplace = workplace;
    }

    public void AddCommand(ICommandParameterBuilder commandParameterBuilder)
    {
        throw new System.NotImplementedException();
    }

    public void Execute(string command)
    {
        throw new System.NotImplementedException();
    }
}