using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Extensions;

public static class StringPathExtension
{
    public static bool IsAbsolute(this string path)
    {
        return Path.IsPathFullyQualified(path);
    }
}