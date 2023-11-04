using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MiscellaneousTestsGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var messageFactory = new MessageFactory();
        var addresseeBuilder = new AddresseeBuilder();

        yield return new object[]
        {
            messageFactory,
            addresseeBuilder,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}