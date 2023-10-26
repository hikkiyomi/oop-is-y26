using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts.ConcreteParts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private readonly RepositoryController _controller = new RepositoryController();
    private readonly ComputerBuildOutcome _workingComputerBuildOutcome;

    public Tests()
    {
        var cpuBuilder = new CpuBuilder();
        var motherboardBuilder = new MotherboardBuilder();
        var coolingSystemBuilder = new CoolingSystemBuilder();
        var ramBuilder = new RamBuilder();
        var gpuBuilder = new GpuBuilder();
        var driveFactory = new HddFactory();
        var pcCaseBuilder = new PcCaseBuilder();

        _controller.Add(
            id: 1,
            cpuBuilder
            .SetSocket(new Am4())
            .SetFrequency(4300)
            .SetCoresAmount(6)
            .SetTdp(65)
            .SetVoltage(65)
            .AddSupportedMemoryFrequency(3500)
            .Build());

        _controller.Add(
            id: 2,
            motherboardBuilder
            .SetBios(new Bios(
                new UefiBios(),
                "2.1",
                new[]
                {
                    _controller.GetById<Cpu>(1),
                }))
            .SetChipset(new XmChipset())
            .SetFormFactor(new Atx())
            .SetSocket(new Am4())
            .SetDdrStandard(new Ddr4())
            .SetWifiModule(new BigWifi())
            .SetPciLinesAmount(5)
            .SetRamSlotsAmount(4)
            .SetSataPortsAmount(6)
            .Build());

        _controller.Add(
            id: 3,
            coolingSystemBuilder
            .SetSize(10, 10, 10)
            .SetMaxTdp(90)
            .AddSocket(new Am4())
            .Build());

        _controller.Add(
            id: 4,
            ramBuilder
            .SetMemory(16)
            .AddSupportedState(3500.0, 30)
            .SetFormFactor(new Dimm())
            .SetDdrStandard(new Ddr4())
            .SetVoltage(30)
            .Build());

        _controller.Add(
            id: 5,
            gpuBuilder
            .SetSize(10, 20, 10)
            .SetMemory(4000)
            .SetPciVersion("3.0")
            .SetFrequency(1500)
            .SetVoltage(90)
            .Build());

        _controller.Add(
            id: 6,
            driveFactory
            .Create(7000, 1024, 30));

        _controller.Add(
            id: 7,
            pcCaseBuilder
            .SetSize(100, 100, 100)
            .SetMaxGpuSize(50, 50, 50)
            .SetMaxCoolingSystemSize(20, 20, 20)
            .AddSupportedFormFactor(new Atx())
            .Build());

        _controller.Add(
            id: 8,
            new PowerSupply(500));

        coolingSystemBuilder.Reset();

        _controller.Add(
            id: 1337,
            coolingSystemBuilder
                .SetSize(10, 10, 10)
                .SetMaxTdp(50)
                .AddSocket(new Am4())
                .Build());

        _controller.Add(
            id: 42,
            new PowerSupply(150));

        cpuBuilder.Reset();

        _controller.Add(
            id: 314,
            cpuBuilder
            .SetSocket(new Fm1())
            .SetFrequency(3000)
            .SetCoresAmount(4)
            .SetTdp(100)
            .SetVoltage(70)
            .AddSupportedMemoryFrequency(2000)
            .Build());

        var pcBuilder = new PersonalComputerBuilder();

        _workingComputerBuildOutcome =
            pcBuilder.SetMotherboard(_controller.GetById<Motherboard>(2))
                .SetCpu(_controller.GetById<Cpu>(1))
                .SetCoolingSystem(_controller.GetById<CoolingSystem>(3))
                .AddRam(_controller.GetById<Ram>(4))
                .AddGpu(_controller.GetById<Gpu>(5))
                .AddDrive(_controller.GetById<Hdd>(6))
                .SetPcCase(_controller.GetById<PcCase>(7))
                .SetPowerSupply(_controller.GetById<PowerSupply>(8))
                .Build();
    }

    [Fact]
    public void BuildShouldBeSuccessful()
    {
        Assert.IsType<BuildResult.Success>(_workingComputerBuildOutcome.Result);
    }

    [Fact]
    public void BuildShouldBeUnstableWarning()
    {
        PersonalComputer? computer = _workingComputerBuildOutcome.Computer;

        if (computer is null)
        {
            throw new TestCanceledException(
                "Something went wrong with test: computer should not be null.");
        }

        var pcBuilder = new PersonalComputerBuilder();
        IPcBuilder customComputerBuilder = computer.Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetPowerSupply(_controller.GetById<PowerSupply>(42))
                .Build();

        Assert.IsType<BuildResult.Warning>(customComputerBuildOutcome.Result);
    }

    [Fact]
    public void BuildShouldBeUnstableWarrantyLoss()
    {
        PersonalComputer? computer = _workingComputerBuildOutcome.Computer;

        if (computer is null)
        {
            throw new TestCanceledException(
                "Something went wrong with test: computer should not be null.");
        }

        var pcBuilder = new PersonalComputerBuilder();
        IPcBuilder customComputerBuilder = computer.Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetCoolingSystem(_controller.GetById<CoolingSystem>(1337))
                .Build();

        Assert.IsType<BuildResult.WarrantyLoss>(customComputerBuildOutcome.Result);
    }

    [Fact]
    public void BuildShouldBeIncompatible()
    {
        PersonalComputer? computer = _workingComputerBuildOutcome.Computer;

        if (computer is null)
        {
            throw new TestCanceledException(
                "Something went wrong with test: computer should not be null.");
        }

        var pcBuilder = new PersonalComputerBuilder();
        IPcBuilder customComputerBuilder = computer.Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetCpu(_controller.GetById<Cpu>(314))
                .Build();

        Assert.IsType<BuildResult.Incompatible>(customComputerBuildOutcome.Result);
    }
}