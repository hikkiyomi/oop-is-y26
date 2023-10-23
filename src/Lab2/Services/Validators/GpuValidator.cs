using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class GpuValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        int pciDriveConnections = pc.Drives
            .Where(drive => drive.Connection is PciConnection)
            .ToList()
            .Count;

        return (pc.Cpu.GraphicsCore is not null || pc.Gpus.Count > 0)
               && pc.Gpus.Count <= pc.Motherboard.PciLines - pciDriveConnections
            ? new BuildResult.Success()
            : new BuildResult.Incompatible("Insufficient PCI lines for GPUs on motherboard.");
    }
}