using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IValidator
{
    BuildResult Validate(PersonalComputer pc);
}