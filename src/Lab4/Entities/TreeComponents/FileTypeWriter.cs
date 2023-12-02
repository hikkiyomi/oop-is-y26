using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeComponents;

public class FileTypeWriter : ITypeWriter
{
    private readonly ConfigParser _parser = new();

    public string GetSymbol()
    {
        return _parser.FindValueByKey("file") ?? "-";
    }

    public string GetIndent()
    {
        return _parser.FindValueByKey("indent") ?? " ";
    }
}