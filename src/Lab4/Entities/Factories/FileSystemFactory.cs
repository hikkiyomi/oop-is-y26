using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;

public class FileSystemFactory
{
    private int _factoriesCreated;

    public IFileSystem Create(string type)
    {
        ++_factoriesCreated;

        return type switch
        {
            "local" => new LocalFileSystem(),
            _ => throw new FileSystemFactoryException("Trying to create unknown file system."),
        };
    }
}