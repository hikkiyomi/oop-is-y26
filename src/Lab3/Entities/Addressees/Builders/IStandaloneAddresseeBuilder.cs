using System;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Builders;

public interface IStandaloneAddresseeBuilder
{
    IStandaloneAddresseeBuilder SetService(IMessageDeliveryService service);
    IStandaloneAddresseeBuilder SetLogger(ILogger logger);
    IStandaloneAddresseeBuilder SetFilter(Func<IMessageEndpoint, bool> filter);
    StandaloneAddressee Build();
}