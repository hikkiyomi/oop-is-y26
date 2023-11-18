using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public interface IWorkplaceState
{
    void AddCommand(ICommandBuilder commandBuilder);
    void Execute(string command);
}