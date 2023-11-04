using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IMessageEndpoint
{
    private readonly Dictionary<int, bool> _receivedMessages = new();

    public User(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; }

    public void Interact(Message message)
    {
        if (_receivedMessages.ContainsKey(message.Id))
        {
            throw new MessageException(
                "User already has received the message with given id.");
        }

        _receivedMessages[message.Id] = false;
    }

    public void MarkRead(Message message)
    {
        if (!_receivedMessages.TryGetValue(message.Id, out bool isRead))
        {
            throw new MessageException(
                "Trying to mark as read the message that never came to such user.");
        }

        if (isRead)
        {
            throw new MessageException(
                "Trying to mark as read the message that was already read.");
        }

        _receivedMessages[message.Id] = true;
    }
}