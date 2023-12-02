using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Drives;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public interface IPcBuilder
{
    void Reset();

    IPcBuilder SetMotherboard(Motherboard motherboard);
    IPcBuilder SetCpu(Cpu cpu);
    IPcBuilder SetCoolingSystem(CoolingSystem coolingSystem);
    IPcBuilder SetPcCase(PcCase pcCase);
    IPcBuilder SetPowerSupply(PowerSupply powerSupply);

    IPcBuilder AddRam(Ram ram);
    IPcBuilder AddGpu(Gpu gpu);
    IPcBuilder AddDrive(IDrive drive);

    ComputerBuildOutcome Build();
}