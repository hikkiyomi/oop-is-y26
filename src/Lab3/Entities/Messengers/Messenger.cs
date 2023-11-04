using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Messenger : IMessageEndpoint
{
    public Messenger(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; }

    public void Interact(Message message)
    {
        Console.WriteLine($"[Messenger]: {message}");
    }
}