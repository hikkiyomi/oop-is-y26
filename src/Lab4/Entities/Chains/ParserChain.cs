using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
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
            else if (args[1].Equals(Go(args[1])?.Name, StringComparison.Ordinal))
            {
                builder.SetActionSignature(args[1]);
                Go(args[1])?.Go(string.Empty)?.Handle(ref builder, ref positionals, args, currentArgument + 1);
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
        int goFrom;

        if (type == ArgumentType.MonoParameter)
        {
            MonoParameterResult result = MonoParameterParser.Parse(args[currentArgument]);
            key = result.Key.Split('-', StringSplitOptions.RemoveEmptyEntries)[0];
            value = result.Value;
            goFrom = currentArgument + 1;
        }
        else
        {
            key = args[currentArgument].Split('-', StringSplitOptions.RemoveEmptyEntries)[0];

            if (currentArgument + 1 >= args.Length)
            {
                throw new ParserContextException("Not every argument has its own value.");
            }

            value = args[currentArgument + 1];
            goFrom = currentArgument + 2;
        }

        builder.AddParameterValue(key, value);
        Go(key)?.Handle(ref builder, ref positionals, args, goFrom);
    }

    public override IParserChainLink Clone()
    {
        return new ParserChain(Name)
        {
            Transitions = Transitions.ToDictionary(
                obj => obj.Key,
                obj => obj.Value.Clone()),
        };
    }

    private ParserChain? Go(string transition)
    {
        return Transitions.TryGetValue(transition, out IParserChainLink? value)
            ? (ParserChain)value
            : null;
    }
}