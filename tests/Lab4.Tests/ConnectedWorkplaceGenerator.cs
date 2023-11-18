using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.States;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ConnectedWorkplaceGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var workplace = new Workplace();

        workplace.ChangeState(new ConnectedWorkplace(
            workplace,
            new MainContext(
                new LocalFileSystem(),
                "/home/wawowewo/")));

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