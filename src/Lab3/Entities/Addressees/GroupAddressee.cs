using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly List<IAddressee> _children;

    public GroupAddressee(IEnumerable<IAddressee> children)
    {
        _children = children.ToList();
    }

    public IReadOnlyCollection<IAddressee> GetChildren() => _children.AsReadOnly();

    public void Add(IAddressee addressee)
        => _children.Add(addressee);

    public void Remove(IAddressee addressee)
        => _children.Remove(addressee);

    public void RedirectMessage(Message message)
    {
        foreach (IAddressee child in _children)
        {
            child.RedirectMessage(message);
        }
    }
}