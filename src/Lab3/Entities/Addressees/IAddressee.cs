using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public interface IAddressee
{
    IMessageDeliveryService? Service { get; }
    ILogger? Logger { get; }
    Func<IMessageEndpoint, bool>? Filter { get; }

    void RedirectMessage(Message message);
}