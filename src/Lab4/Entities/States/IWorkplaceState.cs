using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public interface IWorkplaceState
{
    void AddCommand(CommandContext context);
    void Execute(string command);
}