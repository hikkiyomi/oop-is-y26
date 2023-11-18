using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Extensions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public class MainContext
{
    public MainContext(IFileSystem fileSystem, string currentPath)
    {
        FileSystem = fileSystem;
        CurrentPath = currentPath;

        if (!currentPath.IsAbsolute())
        {
            throw new PathException("Connection path should be absolute.");
        }

        if (!Directory.Exists(currentPath))
        {
            throw new PathException($"There is no directory in given path {currentPath}.");
        }
    }

    public IFileSystem FileSystem { get; }
    public string CurrentPath { get; set; }

    public void GoTo(string path)
    {
        CurrentPath = path;
    }

    public void List(int depth, IOutputMode mode)
    {
        var tree = new CompositeNode(CurrentPath, depth, depth);
        tree.Print(mode);
    }
}