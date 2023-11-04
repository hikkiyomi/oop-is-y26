using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

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