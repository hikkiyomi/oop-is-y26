using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Checkers;

public interface IArgumentTypeChecker
{
    ArgumentType Check(string arg);
}