using Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Workplace
{
    private IWorkplaceState _state = new DisconnectedWorkplace();

    public void ChangeState(IWorkplaceState newState)
    {
        _state = newState;
    }

    public void Execute(string command)
    {
        _state.Execute(command);
    }
}