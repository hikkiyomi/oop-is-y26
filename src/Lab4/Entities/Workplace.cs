using Itmo.ObjectOrientedProgramming.Lab4.Entities.States;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Workplace
{
    private IWorkplaceState _state;

    public Workplace()
    {
        _state = new DisconnectedWorkplace(this);
    }

    public void ChangeState(IWorkplaceState newState)
    {
        _state = newState;
    }

    public void Execute(string command)
    {
        _state.Execute(command);
    }

    public ParseInfoDto GetExecutionInfo(string command)
    {
        return _state.GetExecutionInfo(command);
    }
}