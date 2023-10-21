using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class DriveValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        return pc.Motherboard.SataPorts >= pc.Drives.Count
            ? new BuildResult.Success()
            : new BuildResult.Incompatible();
    }
}