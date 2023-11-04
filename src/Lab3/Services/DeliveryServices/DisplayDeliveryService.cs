using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

public class DisplayDeliveryService : IMessageDeliveryService
{
    private readonly List<IMessageEndpoint> _endpoints;

    public DisplayDeliveryService(IEnumerable<IMessageEndpoint> endpoints)
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
        _endpoints.Remove(endpoint);

        return this;
    }

    public void AcceptMessage(Message message)
    {
        throw new System.NotImplementedException();
    }

    public class ServiceBuilder
    {
        private readonly List<IMessageEndpoint> _data = new();

        public ServiceBuilder AddEndpoint(DisplayScreen userEndpoint)
        {
            _data.Add(userEndpoint);

            return this;
        }

        public DisplayDeliveryService Build()
        {
            return new DisplayDeliveryService(_data);
        }
    }
}