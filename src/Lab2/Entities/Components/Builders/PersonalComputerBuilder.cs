using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class PersonalComputerBuilder : IPcBuilder
{
    private readonly List<Gpu> _gpus = new List<Gpu>();
    private readonly List<IDrive> _drives = new List<IDrive>();
    private readonly List<Ram> _rams = new List<Ram>();

    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private CoolingSystem? _coolingSystem;
    private PcCase? _pcCase;
    private PowerSupply? _powerSupply;

    public void Reset()
    {
        _gpus.Clear();
        _drives.Clear();
        _rams.Clear();

        _motherboard = null;
        _cpu = null;
        _coolingSystem = null;
        _pcCase = null;
        _powerSupply = null;
    }

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

    public PersonalComputerBuilder AddRam(Ram ram)
    {
        _rams.Add(ram);

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

    public ComputerBuildOutcome Build()
    {
        var pc = new PersonalComputer(
            _motherboard ?? throw new PcValidationException("PC should have a motherboard."),
            _cpu ?? throw new PcValidationException("PC should have a CPU"),
            _coolingSystem ?? throw new PcValidationException("PC should have a cooling system."),
            _rams,
            _gpus,
            _drives,
            _pcCase ?? throw new PcValidationException("PC should have a case."),
            _powerSupply ?? throw new PcValidationException("PC should have a power supply."));

        var validator = new ComputerValidator();

        return new ComputerBuildOutcome(pc, validator.Validate(pc));
    }
}