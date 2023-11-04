using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ITopic
{
    string Name { get; }
    IAddressee Addressee { get; }
    void SendMessage(Message message);
}