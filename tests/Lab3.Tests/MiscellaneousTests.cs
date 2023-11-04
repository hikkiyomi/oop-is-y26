using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Writers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MiscellaneousTests
{
    [Theory]
    [ClassData(typeof(MiscellaneousTestsGenerator))]
    public void MessengerDoesNotReceiveMessageWithFiltering(
        MessageFactory messageFactory,
        AddresseeBuilder addresseeBuilder)
    {
        var messenger = new Messenger(
            identifier: "Cool",
            priority: 1,
            new ConsoleWriter());
        Func<IMessageEndpoint, bool>? filter = Substitute.For<Func<IMessageEndpoint, bool>>();

        filter
            .Invoke(Arg.Any<IMessageEndpoint>())
            .Returns(x => ((IMessageEndpoint)x[0]).Priority >= 3);

        StandaloneAddressee addressee =
            addresseeBuilder
                .SetService(MessengerDeliveryService.Builder
                    .AddEndpoint(messenger)
                    .Build())
                .SetFilter(filter)
                .Build();

        var topic = new Topic("VERY COOL TOPIC WOW SUCH USEFUL MANY STYLE", addressee);

        topic.SendMessage(messageFactory.Create("This will not", "be received"));

        Assert.False(filter.Received(1).Invoke(messenger));
    }

    [Theory]
    [ClassData(typeof(MiscellaneousTestsGenerator))]
    public void DisplayReceivedMessageLoggerDoesLogging(
        MessageFactory messageFactory,
        AddresseeBuilder addresseeBuilder)
    {
        var display = new DisplayScreen(
            new DisplayDriver(new ConsoleWriter()),
            Color.Red,
            1);

        ILogger? logger = Substitute.For<ILogger>();

        logger.Log("Hey");

        StandaloneAddressee addressee =
            addresseeBuilder
                .SetService(DisplayDeliveryService.Builder
                    .AddEndpoint(display)
                    .Build())
                .SetLogger(logger)
                .Build();

        var topic = new Topic("VERY COOL TOPIC WOW SUCH USEFUL MANY STYLE", addressee);

        topic.SendMessage(messageFactory.Create("He", "y"));

        logger.Received(1).Log("Hey");
    }

    [Theory]
    [ClassData(typeof(MiscellaneousTestsGenerator))]
    public void MessengerReceivesMessagePrintsExpected(
        MessageFactory messageFactory,
        AddresseeBuilder addresseeBuilder)
    {
        IWriter writer = Substitute.For<IWriter>();
        int counter = 0;

        var messenger = new Messenger(
            identifier: "Cool",
            priority: 1,
            writer);

        Message message = messageFactory.Create("Hello!", "End Test");

        writer
            .When(x => x.Write(messenger.FormText(message)))
            .Do(_ => counter++);

        StandaloneAddressee addressee
            = addresseeBuilder
                .SetService(MessengerDeliveryService.Builder
                    .AddEndpoint(messenger)
                    .Build())
                .Build();

        var topic = new Topic("VERY COOL TOPIC WOW SUCH USEFUL MANY STYLE", addressee);

        topic.SendMessage(messageFactory.Create("Hello!", "End Test"));

        Assert.Equal(1, counter);
        Assert.Equal("[Messenger Cool]:\nHead: Hello!\nBody: End Test", messenger.FormText(message));
    }
}