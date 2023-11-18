using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeComponents;

public class CompositeNode : ITreeNode
{
    private readonly string _name;
    private readonly DirectoryTypeWriter _typeWriter = new();
    private readonly List<ITreeNode> _children = new();
    private int _height;

    public CompositeNode(string path, int depth, int initialDepth)
    {
        string fullName = Path.GetDirectoryName(path)
                ?? throw new PathException($"No directory located in path {path}.");

        _name = Path.GetFileName(fullName);
        _height = initialDepth - depth;

        if (depth <= 1)
        {
            return;
        }

        string[] files = Directory.GetFiles(path);
        string[] directories = Directory.GetDirectories(path);

        foreach (string filePath in files)
        {
            _children.Add(new SingleNode(filePath, initialDepth - depth + 1));
        }

        foreach (string directoryPath in directories)
        {
            _children.Add(new CompositeNode(directoryPath + "/", depth - 1, initialDepth));
        }
    }

    public void Print(IOutputMode mode)
    {
        string message = string.Empty;

        for (int i = 0; i < 4 * _height; ++i)
        {
            message += " ";
        }

        message += $"{_typeWriter.GetSymbol()} {_name}";

        mode.Write(message);

        foreach (ITreeNode child in _children)
        {
            child.Print(mode);
        }
    }
}