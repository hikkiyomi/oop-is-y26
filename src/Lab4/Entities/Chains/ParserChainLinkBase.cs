using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;

public abstract class ParserChainLinkBase : IParserChainLink
{
    protected ParserChainLinkBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public Dictionary<string, IParserChainLink> Transitions { get; protected init; } = new();

    public void AddNext(string transition, IParserChainLink link)
    {
        Transitions[transition] = link;
    }

    public abstract void Handle(
        ref ArgumentBuilder builder,
        ref Collection<string> positionals,
        string[] args,
        int currentArgument);

    public abstract IParserChainLink Clone();

    public bool Equals(ParserChainLinkBase other)
    {
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }
}