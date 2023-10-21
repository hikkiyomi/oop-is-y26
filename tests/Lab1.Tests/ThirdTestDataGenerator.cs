using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ThirdTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new RouteSegment(
                1,
                new NebulaNeutrinoParticles(
                    new[] { new CosmoWhale() })),
            new Waklas(null),
            new Augur(null),
            new Meridian(),
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}