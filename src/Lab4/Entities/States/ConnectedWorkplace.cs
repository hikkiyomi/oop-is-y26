using System;
using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class ConnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly CommandParser _commandParser = new();

    public ConnectedWorkplace(
        Workplace workplace,
        MainContext context)
    {
        _workplace = workplace;
        Context = context;

        var pathCombiner = new ContextPathCombiner(context);

        AddCommand(CommandContext.Builder
            .SetMainSignature("disconnect")
            .SetActionSignature(string.Empty)
            .SetAction(delegate
            {
                _workplace.ChangeState(new DisconnectedWorkplace(_workplace));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("tree")
            .SetActionSignature("goto")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.GoTo(pathCombiner.Combine(positionals[0]));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("tree")
            .SetActionSignature("list")
            .AddParameter("d", "depth")
            .AddParameter("m", "mode")
            .SetAction(delegate(object[] objects)
            {
                var dict = (Dictionary<string, string>)objects[0];
                OutputModeFactory factory = new();

                int depth = dict.TryGetValue("depth", out string? value1)
                    ? int.Parse(
                        value1,
                        new NumberFormatInfo())
                    : 1;

                IOutputMode mode = dict.TryGetValue("mode", out string? value2)
                    ? factory.Create(value2)
                    : new ConsoleMode();

                Context.List(depth, mode);
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("show")
            .AddParameter("m", "mode")
            .SetAction(delegate(object[] objects)
            {
                var dict = (Dictionary<string, string>)objects[0];
                string[] positionals = (string[])objects[1];
                OutputModeFactory factory = new();

                Context.FileSystem.Show(
                    path: pathCombiner.Combine(positionals[0]),
                    mode: factory.Create(dict["mode"]));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("move")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Move(
                    sourcePath: pathCombiner.Combine(positionals[0]),
                    destinationPath: pathCombiner.Combine(positionals[1]));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("copy")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Copy(
                    sourcePath: pathCombiner.Combine(positionals[0]),
                    destinationPath: pathCombiner.Combine(positionals[1]));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("delete")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Delete(path: pathCombiner.Combine(positionals[0]));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("rename")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Rename(
                    path: pathCombiner.Combine(positionals[0]),
                    name: positionals[1]);
            })
            .Build());
    }

    // Тут стоит геттер, потому что в парсер можно добавлять новые команды снаружи этого класса.
    // Если геттера не будет, то юзер не будет знать о контексте - соответственно, не сможет создавать новые команды.
    public MainContext Context { get; }

    public void AddCommand(CommandContext context)
    {
        _commandParser.AddCommand(context);
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