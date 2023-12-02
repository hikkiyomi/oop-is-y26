using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class ComputerValidator : IValidator
{
    private readonly IEnumerable<IValidator> _validators = new IValidator[]
    {
        new CaseValidator(),
        new CpuValidator(),
        new DriveValidator(),
        new GpuValidator(),
        new MotherboardValidator(),
        new PowerSupplyValidator(),
        new RamValidator(),
    };

    public BuildResult Validate(PersonalComputer pc)
    {
        BuildResult? totalResult = _validators
            .Select(validator => validator.Validate(pc))
            .MaxBy(validator => validator.Priority);

        return totalResult ?? new BuildResult.Success();
    }
}