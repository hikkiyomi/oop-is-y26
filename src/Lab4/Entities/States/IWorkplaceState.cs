using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public interface IWorkplaceState
{
    void AddCommand(CommandContext context);
    void Execute(string command);
    ParseInfoDto GetExecutionInfo(string command);
}