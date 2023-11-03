using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public interface IAddressee
{
    void AcceptMessage(Message message);
}