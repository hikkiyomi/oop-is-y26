using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class MessengerAddressee : IAddressee
{
    private readonly Messenger _messenger;
    
    public void AcceptMessage(Message message)
    {
        throw new System.NotImplementedException();
    }
}