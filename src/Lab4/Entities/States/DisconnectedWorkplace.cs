using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class DisconnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly Parser _parser;

    public DisconnectedWorkplace(Workplace workplace)
    {
        _workplace = workplace;
    }

    public void AddCommand(ICommandBuilder commandBuilder)
    {
        throw new System.NotImplementedException();
    }

    public void Execute(string command)
    {
        throw new System.NotImplementedException();
    }
}