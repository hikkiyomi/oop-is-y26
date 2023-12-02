using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

// Статика, потому что класс просто содержит статический метод.
public static class MonoParameterParser
{
    // Статика, потому что метод, который ничего не использует из класса. Жесть.
    public static MonoParameterResult Parse(string arg)
    {
        string[] result = arg.Split('=');

        if (result.Length != 2)
        {
            throw new ParserContextException($"Unknown parameter: {arg}");
        }

        return new MonoParameterResult(result[0], result[1]);
    }
}