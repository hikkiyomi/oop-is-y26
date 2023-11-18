using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class ConnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly MainContext _context;
    private readonly Parser _parser;

    public ConnectedWorkplace(
        Workplace workplace,
        MainContext context)
    {
        _workplace = workplace;
        _context = context;
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