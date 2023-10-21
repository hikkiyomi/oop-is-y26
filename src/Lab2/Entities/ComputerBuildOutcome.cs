using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public record ComputerBuildOutcome(
    PersonalComputer Computer,
    BuildResult Result);