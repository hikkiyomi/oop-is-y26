using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new RouteSegment(50, new NebulaIncreasedDensity(System.Array.Empty<IObstacle>())),
            new Shuttle(),
            new Augur(null),
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}