namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public interface ICommandActionSignatureBuilder
{
    ICommandParameterBuilder SetActionSignature(string signature);
}