using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(DataGenerator))]
    public void BuildShouldBeSuccessful(PersonalComputerBuilder pc)
    {
        ComputerBuildOutcome outcome = pc.Build();

        Assert.IsType<BuildResult.Success>(outcome.Result);
    }
}