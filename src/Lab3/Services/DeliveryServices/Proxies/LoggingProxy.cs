using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices.Proxies;

public class LoggingProxy : IMessageDeliveryService
{
    private readonly IMessageDeliveryService _service;
    private readonly ILogger _logger;

    public LoggingProxy(
        IMessageDeliveryService service,
        ILogger logger)
    {
        _service = service;
        _logger = logger;
    }

    public IReadOnlyCollection<IMessageEndpoint> GetEndpoints()
    {
        _logger.Log($"{_service} called GetEndpoints().");

        return _service.GetEndpoints();
    }

    public IMessageDeliveryService AddEndpoint(IMessageEndpoint endpoint)
    {
        _logger.Log($"{_service} called AddEndpoint({endpoint})");

        return _service.AddEndpoint(endpoint);
    }

    public IMessageDeliveryService RemoveEndpoint(IMessageEndpoint endpoint)
    {
        _logger.Log($"{_service} called RemoveEndpoint({endpoint})");

        return _service.RemoveEndpoint(endpoint);
    }

    public void AcceptMessage(Message message)
    {
        _logger.Log($"{_service} called AcceptMessage({message})");
        _service.AcceptMessage(message);
    }
}