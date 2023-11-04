using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class StandaloneAddressee : IAddressee
{
    public StandaloneAddressee(IMessageDeliveryService service)
    {
        Service = service;
    }

    public IMessageDeliveryService Service { get; }

    public void RedirectMessage(Message message)
    {
        Service.AcceptMessage(message);
    }
}