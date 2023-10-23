using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        if (pc.Motherboard.Bios.SupportedCpu.All(cpu => !cpu.Equals(pc.Cpu)))
        {
            return new BuildResult.Incompatible("CPU is not supported by BIOS.");
        }

        if (pc.Cpu.Tdp > pc.CoolingSystem.MaxTdp)
        {
            return new BuildResult.WarrantyLoss("TDP exceeds the maximum TDP");
        }

        return new BuildResult.Success();
    }
}