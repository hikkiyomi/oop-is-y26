using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MotherboardValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        return pc.Motherboard.Socket.Equals(pc.Cpu.Socket)
               && pc.CoolingSystem.SupportedSockets.Any(socket => socket.Equals(pc.Motherboard.Socket)) // TODO
               && pc.PcCase.SupportedFormFactors.Any(formFactor => formFactor.Equals(pc.Motherboard.FormFactor)) // TODO
            ? new BuildResult.Success()
            : new BuildResult.Incompatible();
    }
}