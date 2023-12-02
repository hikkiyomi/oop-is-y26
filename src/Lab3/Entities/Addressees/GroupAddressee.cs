using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.DeliveryServices;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly List<IAddressee> _children;

    public GroupAddressee(IEnumerable<IAddressee> children)
    {
        _children = children.ToList();
    }

    public IMessageDeliveryService? Service => null;

    public IReadOnlyCollection<IAddressee> GetChildren()
        => _children.AsReadOnly();

    public GroupAddressee Add(IAddressee addressee)
    {
        _children.Add(addressee);

        return this;
    }

    public GroupAddressee Remove(IAddressee addressee)
    {
        _children.Remove(addressee);

        return this;
    }

    public void RedirectMessage(Message message)
    {
        foreach (IAddressee child in _children)
        {
            child.RedirectMessage(message);
        }
    }
}