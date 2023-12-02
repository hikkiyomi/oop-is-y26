using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

public interface IMessageDeliveryService
{
    IReadOnlyCollection<IMessageEndpoint> GetEndpoints();

    IMessageDeliveryService AddEndpoint(IMessageEndpoint endpoint);
    IMessageDeliveryService RemoveEndpoint(IMessageEndpoint endpoint);
    void AcceptMessage(Message message);
}