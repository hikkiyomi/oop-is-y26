using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class DisconnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly Parser _parser = new();

    public DisconnectedWorkplace(Workplace workplace)
    {
        _workplace = workplace;

        _parser.AddCommand(CommandContext.Builder
            .SetMainSignature("connect")
            .SetActionSignature(string.Empty)
            .AddParameter("m", "mode")
            .SetAction(delegate(object[] objects)
            {
                var dict = (Dictionary<string, string>)objects[0];
                string[] positionals = (string[])objects[1];
                FileSystemFactory factory = new();

                _workplace.ChangeState(
                    new ConnectedWorkplace(
                        _workplace,
                        new MainContext(
                            factory.Create(dict["mode"]),
                            positionals[0])));
            })
            .Build());
    }

    public void AddCommand(CommandContext context)
    {
        throw new StateException("Cannot add commands to disconnected context.");
    }

    public void Execute(string command)
    {
        Action action = _parser.Parse(command);
        action.Invoke();
    }
}