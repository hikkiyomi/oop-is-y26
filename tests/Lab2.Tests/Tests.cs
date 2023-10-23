using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(DataGenerator))]
    public void BuildShouldBeSuccessful(IPcBuilder pcBuilder)
    {
        ComputerBuildOutcome outcome = pcBuilder.Build();

        Assert.IsType<BuildResult.Success>(outcome.Result);
    }

    [Theory]
    [ClassData(typeof(DataGenerator))]
    public void BuildShouldBeUnstableWarning(IPcBuilder pcBuilder)
    {
        ComputerBuildOutcome workingComputerBuildOutcome = pcBuilder.Build();

        IPcBuilder customComputerBuilder =
            workingComputerBuildOutcome
                .Computer
                .Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetPowerSupply(RepositoryController.GetById<PowerSupply>(42))
                .Build();

        Assert.IsType<BuildResult.Success>(workingComputerBuildOutcome.Result);
        Assert.IsType<BuildResult.Warning>(customComputerBuildOutcome.Result);
    }

    [Theory]
    [ClassData(typeof(DataGenerator))]
    public void BuildShouldBeUnstableWarrantyLoss(IPcBuilder pcBuilder)
    {
        ComputerBuildOutcome workingComputerBuildOutcome = pcBuilder.Build();

        IPcBuilder customComputerBuilder =
            workingComputerBuildOutcome
                .Computer
                .Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetCoolingSystem(RepositoryController.GetById<CoolingSystem>(1337))
                .Build();

        Assert.IsType<BuildResult.Success>(workingComputerBuildOutcome.Result);
        Assert.IsType<BuildResult.WarrantyLoss>(customComputerBuildOutcome.Result);
    }

    [Theory]
    [ClassData(typeof(DataGenerator))]
    public void BuildShouldBeIncompatible(IPcBuilder pcBuilder)
    {
        ComputerBuildOutcome workingComputerBuildOutcome = pcBuilder.Build();

        IPcBuilder customComputerBuilder =
            workingComputerBuildOutcome
                .Computer
                .Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetCpu(RepositoryController.GetById<Cpu>(314))
                .Build();

        Assert.IsType<BuildResult.Success>(workingComputerBuildOutcome.Result);
        Assert.IsType<BuildResult.Incompatible>(customComputerBuildOutcome.Result);
    }
}