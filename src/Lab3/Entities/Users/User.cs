using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IMessageEndpoint
{
    private readonly Dictionary<int, bool> _messageStatuses = new();

    public User(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; }

    public void Interact(Message message)
    {
        if (_messageStatuses.ContainsKey(message.Id))
        {
            throw new MessageException(
                "User already has received the message with given id.");
        }

        _messageStatuses[message.Id] = false;
    }

    public bool IsRead(Message message)
    {
        if (!_messageStatuses.TryGetValue(message.Id, out bool isRead))
        {
            throw new MessageException(
                "Trying to mark as read the message that never came to such user.");
        }

        return isRead;
    }

    public void MarkRead(Message message)
    {
        if (IsRead(message))
        {
            throw new MessageException(
                "Trying to mark as read the message that was already read.");
        }

        _messageStatuses[message.Id] = true;
    }
}