using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public record ComputerBuildOutcome(
    PersonalComputer? Computer,
    BuildResult Result);