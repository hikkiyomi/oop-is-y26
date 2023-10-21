using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class PersonalComputer
{
    public PersonalComputer(
        Motherboard motherboard,
        Cpu cpu,
        CoolingSystem coolingSystem,
        Ram ram,
        IEnumerable<Gpu> gpus,
        IEnumerable<IDrive> drives,
        PcCase pcCase,
        PowerSupply powerSupply)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        CoolingSystem = coolingSystem;
        Ram = ram;
        Gpus = gpus;
        Drives = drives;
        PcCase = pcCase;
        PowerSupply = powerSupply;
    }

    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public CoolingSystem CoolingSystem { get; }
    public Ram Ram { get; }
    public IEnumerable<Gpu> Gpus { get; }
    public IEnumerable<IDrive> Drives { get; }
    public PcCase PcCase { get; }
    public PowerSupply PowerSupply { get; }
}