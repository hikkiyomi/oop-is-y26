using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices.Proxies;

public class FilteringProxy : IMessageDeliveryService
{
    private readonly IMessageDeliveryService _service;
    private readonly Func<IMessageEndpoint, bool> _filter;

    public FilteringProxy(
        IMessageDeliveryService service,
        Func<IMessageEndpoint, bool> filter)
    {
        _service = service;
        _filter = filter;
    }

    public IReadOnlyCollection<IMessageEndpoint> GetEndpoints()
    {
        return _service.GetEndpoints();
    }

    public IMessageDeliveryService AddEndpoint(IMessageEndpoint endpoint)
    {
        return _service.AddEndpoint(endpoint);
    }

    public IMessageDeliveryService RemoveEndpoint(IMessageEndpoint endpoint)
    {
        return _service.RemoveEndpoint(endpoint);
    }

    public void AcceptMessage(Message message)
    {
        IReadOnlyCollection<IMessageEndpoint> endpoints = _service.GetEndpoints();

        foreach (IMessageEndpoint endpoint in endpoints)
        {
            if (_filter.Invoke(endpoint))
            {
                endpoint.Interact(message);
            }
        }
    }
}