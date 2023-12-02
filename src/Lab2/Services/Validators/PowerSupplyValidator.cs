using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PowerSupplyValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        int sumVoltages = pc.PowerConsumings.Sum(powerConsuming => powerConsuming.Voltage);

        return sumVoltages <= pc.PowerSupply.MaxVoltage
            ? new BuildResult.Success()
            : new BuildResult.Warning("Summary voltage exceeds the maximum voltage.");
    }
}