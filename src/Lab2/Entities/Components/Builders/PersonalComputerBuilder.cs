using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
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

    public IPcBuilder AddGpu(Gpu gpu)
    {
        _gpus.Add(gpu);

        return this;
    }

    public IPcBuilder AddDrive(IDrive drive)
    {
        _drives.Add(drive);

        return this;
    }

    public IPcBuilder AddRam(Ram ram)
    {
        _rams.Add(ram);

        return this;
    }

    public IPcBuilder SetMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public IPcBuilder SetCpu(Cpu cpu)
    {
        _cpu = cpu;

        return this;
    }

    public IPcBuilder SetCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;

        return this;
    }

    public IPcBuilder SetPcCase(PcCase pcCase)
    {
        _pcCase = pcCase;

        return this;
    }

    public IPcBuilder SetPowerSupply(PowerSupply powerSupply)
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
        BuildResult result = validator.Validate(pc);

        Reset();

        return new ComputerBuildOutcome(
            result is BuildResult.Success ? pc : null,
            validator.Validate(pc));
    }
}