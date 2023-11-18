using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeComponents;

public class SingleNode : ITreeNode
{
    private readonly string _name;
    private readonly FileTypeWriter _typeWriter = new();
    private readonly int _height;

    public SingleNode(string path, int height)
    {
        _name = Path.GetFileName(path);
        _height = height;
    }

    public void Print(IOutputMode mode)
    {
        string message = string.Empty;

        for (int i = 0; i < 4 * _height; ++i)
        {
            message += _typeWriter.GetIndent();
        }

        message += $"{_typeWriter.GetSymbol()} {_name}";

        mode.Write(message);
    }
}