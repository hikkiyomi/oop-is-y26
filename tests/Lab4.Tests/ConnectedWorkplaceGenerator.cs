using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ConnectedWorkplaceGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var workplace = new Workplace();
        workplace.Execute("connect /home/wawowewo/ --mode=local");

        yield return new object[]
        {
            workplace,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}