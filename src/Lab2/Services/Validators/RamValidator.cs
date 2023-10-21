using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class RamValidator : IValidator
{
    public BuildResult Validate(PersonalComputer pc)
    {
        if (pc.Ram.Count > pc.Motherboard.RamSlots)
        {
            return new BuildResult.Incompatible();
        }

        bool misc = pc.Ram.Aggregate(
            true,
            (current, ram) => current & ram.DdrStandard == pc.Motherboard.DdrStandard);

        bool misc1 = pc.Ram.Aggregate(
            false,
            (current1, ram)
                => ram.SupportedStates.Aggregate(
                    current1,
                    (current, state)
                        => current | pc.Motherboard.Chipset.AvailableFrequencies
                            .Any(freq => freq <= state.Frequency)));

        if (misc && misc1)
        {
            return new BuildResult.Success();
        }

        if (!pc.Motherboard.Chipset.IsXmpCompatible)
        {
            return new BuildResult.Incompatible();
        }

        foreach (Ram ram in pc.Ram)
        {
            bool profileExist = ram.Profiles
                .Aggregate(
                    false,
                    (current, profile)
                        => current | pc.Cpu.MemoryFrequencies
                            .Any(freq => freq == profile.State.Frequency));

            if (!profileExist)
            {
                return new BuildResult.Incompatible();
            }
        }

        return new BuildResult.Success();
    }
}