using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class PersonalComputerBuilder
{
    private readonly List<Gpu> _gpus = new List<Gpu>();
    private readonly List<IDrive> _drives = new List<IDrive>();

    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private CoolingSystem? _coolingSystem;
    private Ram? _ram;
    private PcCase? _pcCase;
    private PowerSupply? _powerSupply;

    public PersonalComputerBuilder AddGpu(Gpu gpu)
    {
        _gpus.Add(gpu);

        return this;
    }

    public PersonalComputerBuilder AddDrive(IDrive drive)
    {
        _drives.Add(drive);

        return this;
    }

    public PersonalComputerBuilder SetMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public PersonalComputerBuilder SetCpu(Cpu cpu)
    {
        _cpu = cpu;

        return this;
    }

    public PersonalComputerBuilder SetCoolingSystem(CoolingSystem system)
    {
        _coolingSystem = system;

        return this;
    }

    public PersonalComputerBuilder SetRam(Ram ram)
    {
        _ram = ram;

        return this;
    }

    public PersonalComputerBuilder SetPcCase(PcCase pcCase)
    {
        _pcCase = pcCase;

        return this;
    }

    public PersonalComputerBuilder SetPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;

        return this;
    }

    public PersonalComputer Build()
    {
        return new PersonalComputer(
            _motherboard ?? throw new PcValidationException("PC should have a motherboard."),
            _cpu ?? throw new PcValidationException("PC should have a CPU"),
            _coolingSystem ?? throw new PcValidationException("PC should have a cooling system."),
            _ram ?? throw new PcValidationException("PC should have RAM."),
            _gpus,
            _drives,
            _pcCase ?? throw new PcValidationException("PC should have a case."),
            _powerSupply ?? throw new PcValidationException("PC should have a power supply."));
    }
}