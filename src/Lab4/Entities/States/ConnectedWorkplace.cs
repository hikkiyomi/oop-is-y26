using System;
using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.States;

public class ConnectedWorkplace : IWorkplaceState
{
    private readonly Workplace _workplace;
    private readonly Parser _parser = new();

    public ConnectedWorkplace(
        Workplace workplace,
        MainContext context)
    {
        _workplace = workplace;
        Context = context;

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

                Context.CurrentPath = positionals[0];
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("tree")
            .SetActionSignature("list")
            .AddParameter("d", "depth")
            .SetAction(delegate(object[] objects)
            {
                var dict = (Dictionary<string, string>)objects[0];

                Context.List(int.Parse(dict["depth"], new NumberFormatInfo()));
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

                Context.FileSystem.Show(positionals[0], factory.Create(dict["mode"]));
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("move")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Move(positionals[0], positionals[1]);
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("copy")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Copy(positionals[0], positionals[1]);
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("delete")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Delete(positionals[0]);
            })
            .Build());

        AddCommand(CommandContext.Builder
            .SetMainSignature("file")
            .SetActionSignature("rename")
            .SetAction(delegate(object[] objects)
            {
                string[] positionals = (string[])objects[1];

                Context.FileSystem.Rename(positionals[0], positionals[1]);
            })
            .Build());
    }

    public MainContext Context { get; }

    public void AddCommand(CommandContext context)
    {
        _parser.AddCommand(context);
    }

    public void Execute(string command)
    {
        Action action = _parser.Parse(command);
        action.Invoke();
    }
}