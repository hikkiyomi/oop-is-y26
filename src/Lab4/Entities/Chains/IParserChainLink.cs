namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;

public interface IParserChainLink
{
    void AddNext(string transition, IParserChainLink link);
    void Handle(IArgumentBuilder builder, string[] args, int currentArgument);
}