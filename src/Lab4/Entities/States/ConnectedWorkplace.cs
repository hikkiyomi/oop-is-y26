using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class ConnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly MainContext _context;
    private readonly Parser _parser;

    public ConnectedWorkplace(Workplace workplace)
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