using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SecondTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new RouteSegment(
                1,
                new NebulaIncreasedDensity(
                    new[] { new AntiMatterBlast() })),
            new Waklas(null),
            new Waklas(new PhotonDeflector()),
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}