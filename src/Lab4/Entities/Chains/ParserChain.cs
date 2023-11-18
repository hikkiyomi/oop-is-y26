using System;
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

    public override void Handle(ref ArgumentBuilder builder, string[] args, int currentArgument)
    {
        if (currentArgument >= args.Length)
        {
            return;
        }

        var checker = new ArgumentTypeChecker();
        ArgumentType type = checker.Check(args[currentArgument]);

        if (currentArgument == 0)
        {
            if (type != ArgumentType.Positional)
            {
                throw new ParserContextException("First argument should be main signature.");
            }

            builder.SetMainSignature(args[0]);
            Go(args[0]).Handle(ref builder, args, 1);
        }
        else if (currentArgument == 1)
        {
            if (type != ArgumentType.Positional)
            {
                throw new ParserContextException("Second argument should be action signature.");
            }

            builder.SetActionSignature(args[1]);
            Go(args[1]).Go(string.Empty).Handle(ref builder, args, currentArgument + 1);
        }
        else
        {
            if (type == ArgumentType.Positional)
            {
                throw new ParserContextException("Unexpected positional argument.");
            }

            string key;
            string value = string.Empty;

            if (type == ArgumentType.MonoParameter)
            {
                MonoParameterResult result = MonoParameterParser.Parse(args[currentArgument]);
                key = result.Key.Split('-', StringSplitOptions.RemoveEmptyEntries)[0];
                value = result.Value;
            }
            else
            {
                key = args[currentArgument].Split('-', StringSplitOptions.RemoveEmptyEntries)[0];
            }

            for (; currentArgument < args.Length; ++currentArgument)
            {
                ArgumentType currentArgType = checker.Check(args[currentArgument]);

                if (currentArgType == ArgumentType.Positional)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        value = args[currentArgument];
                    }
                    else
                    {
                        value += " " + args[currentArgument];
                    }
                }
                else
                {
                    break;
                }
            }

            builder.AddParameterValue(key, value);
            Go(key).Handle(ref builder, args, currentArgument);
        }
    }

    public override IParserChainLink Clone()
    {
        return new ParserChain(Name)
        {
            Transitions = this.Transitions.ToDictionary(
                obj => obj.Key,
                obj => obj.Value.Clone()),
        };
    }

    public ParserChain Go(string transition)
    {
        return Transitions.TryGetValue(transition, out IParserChainLink? value)
            ? (ParserChain)value
            : throw new TransitionException($"No such transition as {transition}.");
    }
}