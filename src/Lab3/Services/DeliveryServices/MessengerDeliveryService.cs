using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

public class MessengerDeliveryService : IMessageDeliveryService
{
    private readonly List<IMessageEndpoint> _endpoints;

    private MessengerDeliveryService(IEnumerable<IMessageEndpoint> endpoints)
    {
        _endpoints = endpoints.ToList();
    }

    public static ServiceBuilder Builder => new ServiceBuilder();

    public IReadOnlyCollection<IMessageEndpoint> GetEndpoints()
        => _endpoints.AsReadOnly();

    public IMessageDeliveryService AddEndpoint(IMessageEndpoint endpoint)
    {
        _endpoints.Add(endpoint);

        return this;
    }

    public IMessageDeliveryService RemoveEndpoint(IMessageEndpoint endpoint)
    {
        _endpoints.Add(endpoint);

        return this;
    }

    public void AcceptMessage(Message message)
    {
        foreach (IMessageEndpoint endpoint in _endpoints)
        {
            endpoint.Interact(message);
        }
    }

    public class ServiceBuilder
    {
        private readonly List<IMessageEndpoint> _data = new();

        public ServiceBuilder AddEndpoint(Messenger userEndpoint)
        {
            _data.Add(userEndpoint);

            return this;
        }

        public MessengerDeliveryService Build()
        {
            return new MessengerDeliveryService(_data);
        }
    }
}