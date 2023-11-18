using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Extensions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class DisconnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly CommandParser _commandParser = new();

    public DisconnectedWorkplace(Workplace workplace)
    {
        _workplace = workplace;

        _commandParser.AddCommand(CommandContext.Builder
            .SetMainSignature("connect")
            .SetActionSignature(string.Empty)
            .AddParameter("m", "mode")
            .SetAction(delegate(object[] objects)
            {
                var dict = (Dictionary<string, string>)objects[0];
                string[] positionals = (string[])objects[1];
                FileSystemFactory factory = new();

                if (!positionals[0].IsAbsolute())
                {
                    throw new PathException("Connection path should be absolute.");
                }

                _workplace.ChangeState(
                    new ConnectedWorkplace(
                        _workplace,
                        new MainContext(
                            fileSystem: factory.Create(dict["mode"]),
                            currentPath: positionals[0])));
            })
            .Build());
    }

    public void AddCommand(CommandContext context)
    {
        throw new StateException("Cannot add commands to disconnected context.");
    }

    public void Execute(string command)
    {
        Action action = _commandParser.Parse(command);
        action.Invoke();
    }

    public ParseInfoDto GetExecutionInfo(string command)
    {
        return _commandParser.FullParse(command);
    }
}