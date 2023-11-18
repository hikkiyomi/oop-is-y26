namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public interface ICommandBuilder
{
    ICommandBuilder SetMainSignature(string signature);
    ICommandBuilder SetActionSignature(string signature);
    ICommandBuilder AddParameter(char shortName, string fullName);
    ICommandBuilder AddParameter(string fullName);
    void Build();
}