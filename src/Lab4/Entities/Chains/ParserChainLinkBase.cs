using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;

public abstract class ParserChainLinkBase : IParserChainLink
{
    private Dictionary<string, IParserChainLink> _transitions = new();

    protected ParserChainLinkBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public IReadOnlyDictionary<string, IParserChainLink> Transitions
        => _transitions.AsReadOnly();

    public void AddNext(string transition, IParserChainLink link)
    {
        _transitions[transition] = link;
    }

    public abstract void Handle(
        ref ArgumentBuilder builder,
        ref Collection<string> positionals,
        string[] args,
        int currentArgument);

    public bool Equals(ParserChainLinkBase other)
    {
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }
}