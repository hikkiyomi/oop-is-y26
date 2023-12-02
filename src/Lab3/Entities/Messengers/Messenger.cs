using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Messenger : IMessageEndpoint
{
    private readonly string _identifier;
    private readonly IWriter _writer;

    public Messenger(
        string identifier,
        int priority,
        IWriter writer)
    {
        _identifier = identifier;
        Priority = priority;
        _writer = writer;
    }

    public int Priority { get; }

    public string FormText(Message message)
        => $"[Messenger {_identifier}]:\n{message}";

    public void Interact(Message message)
    {
        _writer.Write(FormText(message));
    }
}