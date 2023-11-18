using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Checkers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;

public class ParserChain : ParserChainLinkBase
{
    public ParserChain(string name)
        : base(name)
    {
    }

    public override void Handle(
        ref ArgumentBuilder builder,
        ref Collection<string> positionals,
        string[] args,
        int currentArgument)
    {
        if (currentArgument >= args.Length)
        {
            return;
        }

        var checker = new ArgumentTypeChecker();
        ArgumentType type = checker.Check(args[currentArgument]);

        if (type == ArgumentType.Positional)
        {
            if (args[0].Equals(Go(args[0])?.Name, StringComparison.Ordinal))
            {
                builder.SetMainSignature(args[0]);
                Go(args[0])?.Handle(ref builder, ref positionals, args, 1);
            }
            else if (args.Length > 1 && args[1].Equals(Go(args[1])?.Name, StringComparison.Ordinal))
            {
                builder.SetActionSignature(args[1]);

                ParserChain? nextNode = Go(args[1]);

                if (nextNode is null) return;

                ParserChain? parameterNode = nextNode.Go("parameterNode");

                if (parameterNode is not null)
                {
                    parameterNode.Handle(ref builder, ref positionals, args, currentArgument + 1);
                }
                else
                {
                    nextNode.Handle(ref builder, ref positionals, args, currentArgument + 1);
                }
            }
            else
            {
                positionals.Add(args[currentArgument]);
                Handle(ref builder, ref positionals, args, currentArgument + 1);
            }

            return;
        }

        string key;
        string value;

        if (type == ArgumentType.MonoParameter)
        {
            MonoParameterResult result = MonoParameterParser.Parse(args[currentArgument]);
            key = result.Key.Split('-', StringSplitOptions.RemoveEmptyEntries)[0];
            value = result.Value;
        }
        else
        {
            key = args[currentArgument].Split('-', StringSplitOptions.RemoveEmptyEntries)[0];
            value = "true";
        }

        builder.AddParameterValue(key, value);
        Go(key)?.Handle(ref builder, ref positionals, args, currentArgument + 1);
    }

    private ParserChain? Go(string transition)
    {
        return Transitions.TryGetValue(transition, out IParserChainLink? value)
            ? (ParserChain)value
            : null;
    }
}