using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Writers;

public class FileWriter : IWriter
{
    private readonly string _path;

    public FileWriter(string path)
    {
        _path = path;
    }

    public void Write(string text)
    {
        using var writer = new StreamWriter(_path, append: true);
        writer.WriteLine(text);
    }

    public void Clear()
    {
        using var writer = new StreamWriter(_path);
    }
}