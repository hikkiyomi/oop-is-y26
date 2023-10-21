using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PersonalComputer
{
    private readonly List<IPowerConsuming> _powerConsumings;

    public PersonalComputer(
        Motherboard motherboard,
        Cpu cpu,
        CoolingSystem coolingSystem,
        IEnumerable<Ram> ram,
        IEnumerable<Gpu> gpus,
        IEnumerable<IDrive> drives,
        PcCase pcCase,
        PowerSupply powerSupply)
    {
        IEnumerable<Gpu> enumerable = gpus.ToList();
        IEnumerable<IDrive> enumerable1 = drives.ToList();
        IEnumerable<Ram> rams = ram.ToList();

        Motherboard = motherboard;
        Cpu = cpu;
        CoolingSystem = coolingSystem;
        Ram = rams.ToList();
        Gpus = enumerable.ToList();
        Drives = enumerable1.ToList();
        PcCase = pcCase;
        PowerSupply = powerSupply;

        _powerConsumings = new List<IPowerConsuming>() { cpu };

        if (motherboard.WifiModule is not null)
        {
            _powerConsumings.Add(motherboard.WifiModule);
        }

        foreach (Gpu gpu in enumerable)
        {
            _powerConsumings.Add(gpu);
        }

        foreach (IDrive drive in enumerable1)
        {
            _powerConsumings.Add(drive);
        }

        foreach (Ram ramPlate in rams)
        {
            _powerConsumings.Add(ramPlate);
        }
    }

    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public CoolingSystem CoolingSystem { get; }
    public ICollection<Ram> Ram { get; }
    public ICollection<Gpu> Gpus { get; }
    public ICollection<IDrive> Drives { get; }
    public PcCase PcCase { get; }
    public PowerSupply PowerSupply { get; }
    public IReadOnlyCollection<IPowerConsuming> PowerConsumings
        => _powerConsumings.AsReadOnly();

    public PersonalComputerBuilder Direct(PersonalComputerBuilder builder)
    {
        builder.Reset();
        builder.SetMotherboard(Motherboard);
        builder.SetCpu(Cpu);
        builder.SetCoolingSystem(CoolingSystem);
        builder.SetPcCase(PcCase);
        builder.SetPowerSupply(PowerSupply);

        foreach (Ram ram in Ram)
        {
            builder.AddRam(ram);
        }

        foreach (Gpu gpu in Gpus)
        {
            builder.AddGpu(gpu);
        }

        foreach (IDrive drive in Drives)
        {
            builder.AddDrive(drive);
        }

        return builder;
    }
}