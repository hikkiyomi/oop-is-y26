using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ForthTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Stella(null), typeof(TravelResult.Destroyed) };
        yield return new object[] { new Meridian(), typeof(TravelResult.CrewDeath) };
        yield return new object[] { new Waklas(new PhotonDeflector()), typeof(TravelResult.Destroyed) };
        yield return new object[] { new Augur(null), typeof(TravelResult.CrewDeath) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}