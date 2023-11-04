using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public interface IAddressee
{
    IMessageDeliveryService? Service { get; }

    void RedirectMessage(Message message);
}