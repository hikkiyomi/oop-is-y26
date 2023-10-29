using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

[Collection("Database collection")]
public class Tests
{
    private readonly DatabaseFixture _fixture;

    public Tests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void BuildShouldBeSuccessful()
    {
        Assert.IsType<BuildResult.Success>(_fixture.WorkingComputerBuildOutcome.Result);
    }

    [Fact]
    public void BuildShouldBeUnstableWarning()
    {
        PersonalComputer? computer = _fixture.WorkingComputerBuildOutcome.Computer;

        if (computer is null)
        {
            throw new TestCanceledException(
                "Something went wrong with test: computer should not be null.");
        }

        var pcBuilder = new PersonalComputerBuilder();
        IPcBuilder customComputerBuilder = computer.Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetPowerSupply(_fixture.Controller.GetComponentById<PowerSupply>(42))
                .Build();

        Assert.IsType<BuildResult.Warning>(customComputerBuildOutcome.Result);
    }

    [Fact]
    public void BuildShouldBeUnstableWarrantyLoss()
    {
        PersonalComputer? computer = _fixture.WorkingComputerBuildOutcome.Computer;

        if (computer is null)
        {
            throw new TestCanceledException(
                "Something went wrong with test: computer should not be null.");
        }

        var pcBuilder = new PersonalComputerBuilder();
        IPcBuilder customComputerBuilder = computer.Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetCoolingSystem(_fixture.Controller.GetComponentById<CoolingSystem>(1337))
                .Build();

        Assert.IsType<BuildResult.WarrantyLoss>(customComputerBuildOutcome.Result);
    }

    [Fact]
    public void BuildShouldBeIncompatible()
    {
        PersonalComputer? computer = _fixture.WorkingComputerBuildOutcome.Computer;

        if (computer is null)
        {
            throw new TestCanceledException(
                "Something went wrong with test: computer should not be null.");
        }

        var pcBuilder = new PersonalComputerBuilder();
        IPcBuilder customComputerBuilder = computer.Direct(pcBuilder);

        ComputerBuildOutcome customComputerBuildOutcome =
            customComputerBuilder
                .SetCpu(_fixture.Controller.GetComponentById<Cpu>(314))
                .Build();

        Assert.IsType<BuildResult.Incompatible>(customComputerBuildOutcome.Result);
    }
}