using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public void Show(string path, IOutputMode mode)
    {
        if (!File.Exists(path))
        {
            throw new FileSystemException($"File {path} does not exist.");
        }

        using (var reader = new StreamReader(path))
        {
            string? line;

            while ((line = reader.ReadLine()) is not null)
            {
                mode.Write(line);
            }
        }
    }

    public void Move(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileSystemException($"File {sourcePath} does not exist.");
        }

        if (File.Exists(destinationPath))
        {
            throw new FileSystemException($"Cannot move a file to {destinationPath}. There is already a file with the same name.");
        }

        File.Move(sourcePath, destinationPath);
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileSystemException($"File {sourcePath} does not exist.");
        }

        if (File.Exists(destinationPath))
        {
            throw new FileSystemException($"Cannot move a file to {destinationPath}. There is already a file with the same name.");
        }

        File.Copy(sourcePath, destinationPath);
    }

    public void Delete(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileSystemException($"There is no such file as {path}.");
        }

        File.Delete(path);
    }

    public void Rename(string path, string name)
    {
        if (!File.Exists(path))
        {
            throw new FileSystemException($"There is no such file as {path}.");
        }

        string directoryPath = Path.GetDirectoryName(path)
                               ?? throw new InvalidOperationException();

        string newPath = Path.Combine(directoryPath, name);

        File.Move(path, newPath);
    }
}