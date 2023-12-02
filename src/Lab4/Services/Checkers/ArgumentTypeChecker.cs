using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Checkers;

public class ArgumentTypeChecker : IArgumentTypeChecker
{
    public ArgumentType Check(string arg)
    {
        if (arg[0] == '-' && arg.Contains('=', StringComparison.Ordinal))
        {
            return ArgumentType.MonoParameter;
        }

        return arg[0] switch
        {
            '-' => ArgumentType.Parameter,
            _ => ArgumentType.Positional,
        };
    }
}