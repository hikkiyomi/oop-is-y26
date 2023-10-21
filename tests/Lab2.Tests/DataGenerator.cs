using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts.ConcreteParts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class DataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var cpuBuilder = new CpuBuilder();

        RepositoryController.Add(1, cpuBuilder
            .SetSocket(new Am4())
            .SetFrequency(4300)
            .SetCoresAmount(6)
            .SetTdp(65)
            .SetVoltage(65)
            .AddSupportedMemoryFrequency(3500)
            .Build());

        var motherboardBuilder = new MotherboardBuilder();

        RepositoryController.Add(2, motherboardBuilder
            .SetBios(new Bios(
                new UefiBios(),
                "2.1",
                new[]
                {
                    RepositoryController
                        .GetById<Cpu>(1)
                        .Clone(),
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

        var coolingSystemBuilder = new CoolingSystemBuilder();

        RepositoryController.Add(3, coolingSystemBuilder
            .SetSize(10, 10, 10)
            .SetMaxTdp(90)
            .AddSocket(new Am4())
            .Build());

        var ramBuilder = new RamBuilder();

        RepositoryController.Add(4, ramBuilder
            .SetMemory(16)
            .AddSupportedState(3500.0, 30)
            .SetFormFactor(new Dimm())
            .SetDdrStandard(new Ddr4())
            .SetVoltage(30)
            .Build());

        var gpuBuilder = new GpuBuilder();

        RepositoryController.Add(5, gpuBuilder
            .SetSize(10, 20, 10)
            .SetMemory(4000)
            .SetPciVersion("3.0")
            .SetFrequency(1500)
            .SetVoltage(90)
            .Build());

        var driveFactory = new HddFactory();

        RepositoryController.Add(6, driveFactory
            .Create(7000, 1024, 30));

        var pcCaseBuilder = new PcCaseBuilder();

        RepositoryController.Add(7, pcCaseBuilder
            .SetSize(100, 100, 100)
            .SetMaxGpuSize(50, 50, 50)
            .SetMaxCoolingSystemSize(20, 20, 20)
            .AddSupportedFormFactor(new Atx())
            .Build());

        RepositoryController.Add(8, new PowerSupply(500));

        var pcBuilder = new PersonalComputerBuilder();

        yield return new object[]
        {
            pcBuilder.SetMotherboard(RepositoryController.GetById<Motherboard>(2))
                .SetCpu(RepositoryController.GetById<Cpu>(1))
                .SetCoolingSystem(RepositoryController.GetById<CoolingSystem>(3))
                .AddRam(RepositoryController.GetById<Ram>(4))
                .AddGpu(RepositoryController.GetById<Gpu>(5))
                .AddDrive(RepositoryController.GetById<Hdd>(6))
                .SetPcCase(RepositoryController.GetById<PcCase>(7))
                .SetPowerSupply(RepositoryController.GetById<PowerSupply>(8)),
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}