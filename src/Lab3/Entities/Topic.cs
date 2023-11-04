using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private readonly string _name;
    private readonly IAddressee _addressee;

    public Topic(
        string name,
        IAddressee addressee)
    {
        _name = name;
        _addressee = addressee;
    }

    public void SendMessage(Message message)
    {
        _addressee.RedirectMessage(message);
    }
}