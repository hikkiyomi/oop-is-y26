using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;

public interface IFileSystem
{
    void Show(string path, IOutputMode mode);
    void Move(string sourcePath, string destinationPath);
    void Copy(string sourcePath, string destinationPath);
    void Delete(string path);
    void Rename(string path, string name);
}