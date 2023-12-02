using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts.ConcreteParts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class DatabaseFixture
{
    public DatabaseFixture()
    {
        var cpuBuilder = new CpuBuilder();
        var motherboardBuilder = new MotherboardBuilder();
        var coolingSystemBuilder = new CoolingSystemBuilder();
        var ramBuilder = new RamBuilder();
        var gpuBuilder = new GpuBuilder();
        var driveFactory = new HddFactory();
        var pcCaseBuilder = new PcCaseBuilder();

        Controller.Add(
            id: 1,
            cpuBuilder
            .SetSocket(new Am4())
            .SetFrequency(4300)
            .SetCoresAmount(6)
            .SetTdp(65)
            .SetVoltage(65)
            .AddSupportedMemoryFrequency(3500)
            .Build());

        Controller.Add(
            id: 2,
            motherboardBuilder
            .SetBios(new Bios(
                new UefiBios(),
                "2.1",
                new[]
                {
                    Controller.GetComponentById<Cpu>(1),
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

        Controller.Add(
            id: 3,
            coolingSystemBuilder
            .SetSize(10, 10, 10)
            .SetMaxTdp(90)
            .AddSocket(new Am4())
            .Build());

        Controller.Add(
            id: 4,
            ramBuilder
            .SetMemory(16)
            .AddSupportedState(3500.0, 30)
            .SetFormFactor(new Dimm())
            .SetDdrStandard(new Ddr4())
            .SetVoltage(30)
            .Build());

        Controller.Add(
            id: 5,
            gpuBuilder
            .SetSize(10, 20, 10)
            .SetMemory(4000)
            .SetPciVersion("3.0")
            .SetFrequency(1500)
            .SetVoltage(90)
            .Build());

        Controller.Add(
            id: 6,
            driveFactory
            .Create(7000, 1024, 30));

        Controller.Add(
            id: 7,
            pcCaseBuilder
            .SetSize(100, 100, 100)
            .SetMaxGpuSize(50, 50, 50)
            .SetMaxCoolingSystemSize(20, 20, 20)
            .AddSupportedFormFactor(new Atx())
            .Build());

        Controller.Add(
            id: 8,
            new PowerSupply(500));

        Controller.Add(
            id: 1337,
            coolingSystemBuilder
                .SetSize(10, 10, 10)
                .SetMaxTdp(50)
                .AddSocket(new Am4())
                .Build());

        Controller.Add(
            id: 42,
            new PowerSupply(150));

        Controller.Add(
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

        WorkingComputerBuildOutcome =
            pcBuilder.SetMotherboard(Controller.GetComponentById<Motherboard>(2))
                .SetCpu(Controller.GetComponentById<Cpu>(1))
                .SetCoolingSystem(Controller.GetComponentById<CoolingSystem>(3))
                .AddRam(Controller.GetComponentById<Ram>(4))
                .AddGpu(Controller.GetComponentById<Gpu>(5))
                .AddDrive(Controller.GetComponentById<Hdd>(6))
                .SetPcCase(Controller.GetComponentById<PcCase>(7))
                .SetPowerSupply(Controller.GetComponentById<PowerSupply>(8))
                .Build();
    }

    // Конструктор контроллера не принимает аргументы, потому что
    // он работает с синглтоновым репозиторием.
    // Все контроллеры будут отсылаться на один репозиторий. Так задумано.
    public RepositoryController Controller { get; } = new RepositoryController();
    public ComputerBuildOutcome WorkingComputerBuildOutcome { get; }
}