using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class CommandParser
{
    private readonly Dictionary<CommandIdentifier, CommandContext> _context = new();
    private readonly ParserChain _root = new(string.Empty);
    private Collection<string> _positionals = new();

    public void AddCommand(CommandContext context)
    {
        if (_context.ContainsKey(context.Id))
        {
            throw new ParserContextException("The command with the same id already exists.");
        }

        _context[context.Id] = context;

        AddChain(_root, context.Chain);
    }

    public ParseInfoDto FullParse(string command)
    {
        string[] split = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var argumentBuilder = new ArgumentBuilder();

        _root.Handle(ref argumentBuilder, ref _positionals, split, 0);

        ArgumentContext parsedContext = argumentBuilder.Build();

        if (!_context.TryGetValue(parsedContext.Id, out CommandContext? value))
        {
            throw new ParserContextException($"No such context as {parsedContext.Id}");
        }

        CommandContext existingContext = value;

        foreach (string param in parsedContext
                     .Parameters
                     .Keys
                     .Where(param => existingContext
                         .FindParameterByName(param) is null))
        {
            throw new ParserContextException($"Unknown parameter {param}");
        }

        var contextByFullName
            = parsedContext
                .Parameters
                .ToDictionary(
                    item => existingContext.GetParameterFullName(item.Key),
                    item => item.Value);

        return new ParseInfoDto(
            Id: parsedContext.Id,
            Context: contextByFullName,
            Positionals: _positionals.AsReadOnly(),
            OriginalCommand: existingContext.Action,
            CommandToInvoke: () =>
            {
                existingContext.Action.Invoke(
                    new object[]
                    {
                        contextByFullName,
                        _positionals.ToArray(),
                    });
            });
    }

    public Action Parse(string command)
    {
        return FullParse(command).CommandToInvoke;
    }

    // Пометил статикой, потому что метод не использует информацию из класса.
    // Иначе анализатор ругается(
    private static void AddChain(ParserChain currentRootChain, ParserChainLinkBase currentCommandChain)
    {
        if (!currentRootChain.Transitions.ContainsKey(currentCommandChain.Name))
        {
            IParserChainLink next = new ParserChain(currentCommandChain.Name);
            currentRootChain.AddNext(currentCommandChain.Name, next);
        }

        currentRootChain = (ParserChain)currentRootChain.Transitions[currentCommandChain.Name];

        foreach (KeyValuePair<string, IParserChainLink> transition in currentCommandChain.Transitions)
        {
            AddChain(currentRootChain, (ParserChain)transition.Value);
        }
    }
}