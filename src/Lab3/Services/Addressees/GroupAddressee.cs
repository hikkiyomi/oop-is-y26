using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly Collection<IAddressee> _children = new();

    public IReadOnlyCollection<IAddressee> GetChildren() => _children.AsReadOnly();

    public void Add(IAddressee addressee)
        => _children.Add(addressee);

    public void Remove(IAddressee addressee)
        => _children.Remove(addressee);

    public void AcceptMessage(Message message)
    {
        foreach (IAddressee child in _children)
        {
            child.AcceptMessage(message);
        }
    }
}