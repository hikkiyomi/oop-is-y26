using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices.Proxies;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Builders;

public sealed class AddresseeBuilder : IAddresseeBuilder
{
    private readonly List<IAddressee> _addressees = new();
    private IMessageDeliveryService? _service;
    private ILogger? _logger;
    private Func<IMessageEndpoint, bool>? _filter;

    public IStandaloneAddresseeBuilder SetService(IMessageDeliveryService service)
    {
        _service = service;

        return this;
    }

    public IStandaloneAddresseeBuilder SetLogger(ILogger logger)
    {
        _logger = logger;

        return this;
    }

    public IStandaloneAddresseeBuilder SetFilter(Func<IMessageEndpoint, bool> filter)
    {
        _filter = filter;

        return this;
    }

    public IGroupAddresseeBuilder AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);

        return this;
    }

    GroupAddressee IGroupAddresseeBuilder.Build()
    {
        return new GroupAddressee(_addressees);
    }

    StandaloneAddressee IStandaloneAddresseeBuilder.Build()
    {
        if (_service is null)
        {
            throw new AddresseeBuilderException(
                "No service was provided to builder.");
        }

        if (_filter is not null)
        {
            _service = new FilteringProxy(_service, _filter);
        }

        if (_logger is not null)
        {
            _service = new LoggingProxy(_service, _logger);
        }

        return new StandaloneAddressee(_service);
    }
}