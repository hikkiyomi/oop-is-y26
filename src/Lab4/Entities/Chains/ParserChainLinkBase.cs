using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;

public abstract class ParserChainLinkBase : IParserChainLink
{
    protected Dictionary<string, IParserChainLink> Transitions { get; } = new();

    public void AddNext(string transition, IParserChainLink link)
    {
        Transitions[transition] = link;
    }

    public abstract void Handle(IArgumentBuilder builder, string[] args, int currentArgument);
}