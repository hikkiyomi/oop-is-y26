using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IMessageEndpoint
{
    int Priority { get; }
    void Interact(Message message);
}