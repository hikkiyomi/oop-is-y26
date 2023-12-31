using System.Collections;
using System.Collections.Generic;
using Lab5.Application.Accounts;
using Lab5.Application.Models;
using Lab5.Application.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var handler = new UserHandler();
        var accHandler = new AccountHandler();

        handler.User = new User("user", "1234", Mode.User);
        accHandler.Account = new BankAccount("user", "1234", "1234", 13);

        yield return new object[]
        {
            handler,
            accHandler,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}