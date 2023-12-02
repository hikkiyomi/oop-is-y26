using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Extensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CaseValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        bool coolerStatement = pc.CoolingSystem.Size.IsLess(pc.PcCase.MaxCoolingSize);
        bool gpuStatement = pc.Gpus.Aggregate(
            true,
            (current, gpu) => current & gpu.Size.IsLess(pc.PcCase.MaxGpuSize));

        if (!coolerStatement)
        {
            return new BuildResult.Incompatible("Case is not compatible with cooler.");
        }

        return gpuStatement
            ? new BuildResult.Success()
            : new BuildResult.Incompatible("Case is not compatible with GPU.");
    }
}