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
        var user = new User(priority: 1);

        StandaloneAddressee addressee =
            addresseeBuilder
                .SetService(UserDeliveryService.Builder
                    .AddEndpoint(user)
                    .Build())
                .Build();

        yield return new object[]
        {
            messageFactory.Create("Hello", "World"),
            user,
            addressee,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}