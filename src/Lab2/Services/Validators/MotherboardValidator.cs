using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MotherboardValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        return pc.Motherboard.Socket == pc.Cpu.Socket
               && pc.CoolingSystem.SupportedSockets.Any(socket => socket == pc.Motherboard.Socket)
               && pc.PcCase.SupportedFormFactors.Any(formFactor => formFactor == pc.Motherboard.FormFactor)
            ? new BuildResult.Success()
            : new BuildResult.Incompatible();
    }
}