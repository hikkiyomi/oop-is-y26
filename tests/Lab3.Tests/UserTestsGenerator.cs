using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UserTestsGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var messageFactory = new MessageFactory();
        var addresseeBuilder = new AddresseeBuilder();
        var userEndpoint = new User(priority: 1);

        StandaloneAddressee addressee =
            addresseeBuilder
                .SetService(UserDeliveryService.Builder
                    .AddEndpoint(userEndpoint)
                    .Build())
                .Build();

        yield return new object[]
        {
            messageFactory.Create("Hello", "World", 1),
            userEndpoint,
            addressee,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}