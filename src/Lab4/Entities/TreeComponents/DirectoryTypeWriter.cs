using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeComponents;

public class DirectoryTypeWriter : ITypeWriter
{
    private readonly ConfigParser _parser = new();

    public string GetSymbol()
    {
        return _parser.FindValueByKey("directory") ?? "#";
    }
}