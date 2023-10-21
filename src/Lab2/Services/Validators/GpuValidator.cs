using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class GpuValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        return (pc.Cpu.GraphicsCore is not null || pc.Gpus.Count > 0)
               && pc.Gpus.Count <= pc.Motherboard.PciLines
            ? new BuildResult.Success()
            : new BuildResult.Incompatible();
    }
}