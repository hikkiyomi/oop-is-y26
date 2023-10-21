using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CaseValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        bool coolerStatement = IsLess(pc.CoolingSystem.Size, pc.PcCase.MaxCoolingSize);
        bool gpuStatement = pc.Gpus.Aggregate(true, (current, gpu) => current & IsLess(gpu.Size, pc.PcCase.MaxGpuSize));

        return coolerStatement && gpuStatement
            ? new BuildResult.Success()
            : new BuildResult.Incompatible();
    }

    private static bool IsLess(Dimensions dimensions1, Dimensions dimensions2)
    {
        return dimensions1.Length <= dimensions2.Length
               && dimensions1.Width <= dimensions2.Width
               && dimensions1.Height <= dimensions2.Height;
    }
}