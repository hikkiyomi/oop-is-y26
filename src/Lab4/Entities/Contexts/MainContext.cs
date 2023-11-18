using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public class MainContext
{
    public MainContext(IFileSystem fileSystem, string currentPath)
    {
        FileSystem = fileSystem;
        CurrentPath = currentPath;
    }

    public IFileSystem FileSystem { get; }
    public string CurrentPath { get; set; }

    public void GoTo(string path)
    {
        CurrentPath = path;
    }

    public void List(int depth)
    {
        throw new NotImplementedException();
    }
}