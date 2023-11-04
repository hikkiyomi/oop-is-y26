using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessageFactory
{
    private const int StartingId = 1;
    private int _freeId = StartingId;

    public Message Create(
        string head,
        string body)
    {
        return new Message(_freeId++, head, body);
    }
}