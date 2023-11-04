using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IMessageEndpoint
{
    private readonly HashSet<int> _readMessages = new();

    public User(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; }

    public void Interact(Message message)
    {
        if (_readMessages.Contains(message.Id))
        {
            throw new MessageIsReadException(
                "Trying to read already seen message.");
        }

        _readMessages.Add(message.Id);
    }
}