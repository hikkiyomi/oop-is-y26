using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UserTests
{
    [Theory]
    [ClassData(typeof(UserTestsGenerator))]
    public void UserReceiveMessageShouldBeUnread(
        Message message,
        User user,
        StandaloneAddressee addressee)
    {
        addressee.RedirectMessage(message);

        Assert.False(user.IsRead(message));
    }

    [Theory]
    [ClassData(typeof(UserTestsGenerator))]
    public void UserReceiveMessageAndReadShouldBeOk(
        Message message,
        User user,
        StandaloneAddressee addressee)
    {
        addressee.RedirectMessage(message);

        Exception? exception = Record.Exception(() =>
        {
            user.MarkRead(message);
        });

        Assert.Null(exception);
        Assert.True(user.IsRead(message));
    }

    [Theory]
    [ClassData(typeof(UserTestsGenerator))]
    public void UserReceiveMessageAndReadTwiceShouldBeBad(
        Message message,
        User user,
        StandaloneAddressee addressee)
    {
        addressee.RedirectMessage(message);
        user.MarkRead(message);

        Exception? exception = Record.Exception(() =>
        {
            user.MarkRead(message);
        });

        Assert.NotNull(exception);
    }
}