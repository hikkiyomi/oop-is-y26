using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public static class StringPathExtension
{
    public static bool IsAbsolute(this string path)
    {
        return Path.IsPathFullyQualified(path);
    }
}