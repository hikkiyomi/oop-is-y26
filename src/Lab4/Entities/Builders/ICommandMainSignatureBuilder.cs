namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public interface ICommandMainSignatureBuilder
{
    ICommandActionSignatureBuilder SetMainSignature(string signature);
}