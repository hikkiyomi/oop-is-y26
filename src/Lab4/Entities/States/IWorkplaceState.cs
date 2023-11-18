using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public interface IWorkplaceState
{
    void AddCommand(ICommandParameterBuilder commandParameterBuilder);
    void Execute(string command);
}