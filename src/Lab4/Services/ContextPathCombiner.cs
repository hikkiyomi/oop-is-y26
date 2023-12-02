using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Extensions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ContextPathCombiner
{
    private readonly MainContext _context;

    public ContextPathCombiner(MainContext context)
    {
        _context = context;
    }

    public string Combine(string path)
    {
        if (!_context.CurrentPath.IsAbsolute())
        {
            throw new CombinerException("Context path should be absolute.");
        }

        return path.IsAbsolute()
            ? path
            : Path.GetFullPath(Path.Combine(_context.CurrentPath, path));
    }
}