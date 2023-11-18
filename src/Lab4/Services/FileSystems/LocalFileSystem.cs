using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public void Show(string path, IOutputMode mode)
    {
        throw new System.NotImplementedException();
    }

    public void Move(string sourcePath, string destinationPath)
    {
        throw new System.NotImplementedException();
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(string path)
    {
        throw new System.NotImplementedException();
    }

    public void Rename(string path, string name)
    {
        throw new System.NotImplementedException();
    }
}