using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class StandaloneAddressee : IAddressee
{
    public StandaloneAddressee(
        IMessageDeliveryService service,
        ILogger logger,
        Func<IMessageEndpoint, bool> filter)
    {
        Service = service;
        Logger = logger;
        Filter = filter;
    }

    public IMessageDeliveryService Service { get; }
    public ILogger Logger { get; }
    public Func<IMessageEndpoint, bool> Filter { get; }

    public void RedirectMessage(Message message)
    {
        Service.AcceptMessage(message);
    }
}