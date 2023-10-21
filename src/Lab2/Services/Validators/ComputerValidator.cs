using System.Collections.Generic;
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
        foreach (IValidator validator in _validators)
        {
            BuildResult result = validator.Validate(pc);

            if (result is not BuildResult.Success)
            {
                return result;
            }
        }

        return new BuildResult.Success();
    }
}