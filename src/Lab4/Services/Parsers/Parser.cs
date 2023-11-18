using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class Parser
{
    private readonly Dictionary<CommandIdentifier, CommandContext> _context = new();
    private readonly ParserChain _root = new();

    public void AddCommand(ICommandBuilder commandBuilder)
    {
        throw new NotImplementedException();
    }

    public void Parse(string arguments)
    {
        throw new NotImplementedException();
    }
}