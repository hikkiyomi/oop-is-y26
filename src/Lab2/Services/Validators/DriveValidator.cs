using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.DriveConnections;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class DriveValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        int sataConnections = pc.Drives
            .Where(drive => drive.Connection is SataConnection)
            .ToList()
            .Count;

        int pciConnections = pc.Drives
            .Where(drive => drive.Connection is PciConnection)
            .ToList()
            .Count;

        if (pc.Motherboard.SataPorts < sataConnections)
        {
            return new BuildResult.Incompatible("Insufficient SATA ports on motherboard.");
        }

        return pc.Motherboard.PciLines >= pciConnections
            ? new BuildResult.Success()
            : new BuildResult.Incompatible("Insufficient PCI lines for drives on motherboard.");
    }
}