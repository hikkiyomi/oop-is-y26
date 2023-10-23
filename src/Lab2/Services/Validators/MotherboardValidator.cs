using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MotherboardValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        if (!pc.Motherboard.Socket.Equals(pc.Cpu.Socket))
        {
            return new BuildResult.Incompatible("Motherboard socket is not compatible with CPU socket");
        }

        if (!pc.CoolingSystem.SupportedSockets
                .Any(socket => socket.Equals(pc.Motherboard.Socket)))
        {
            return new BuildResult.Incompatible("Motherboard socket is not compatible with any of cooling system sockets.");
        }

        return pc.PcCase.SupportedFormFactors
            .Any(formFactor => formFactor.Equals(pc.Motherboard.FormFactor))
            ? new BuildResult.Success()
            : new BuildResult.Incompatible("Motherboard form factor is not compatible with PC case.");
    }
}