using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;

public interface IParserChainLink
{
    void AddNext(string transition, IParserChainLink link);
    void Handle(ref ArgumentBuilder builder, string[] args, int currentArgument);
    IParserChainLink Clone();
}